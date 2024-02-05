using FluentValidation;
using IDrobeAPI.Application.Exceptions.CustomExceptions;
using IDrobeAPI.Application.Exceptions.Problems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    //todo log yazdir ExxeptionMiddlware
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;

        if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
        if (exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
        if (exception.GetType() == typeof(AuthorizationException)) return CreateAuthorizationException(context, exception);
        return CreateInternalException(context, exception);
    }

    private Task CreateAuthorizationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

        return context.Response.WriteAsync(new AuthorizationProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = "https://idrobe.com/probs/authorization",
            Title = "Authorization exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateBusinessException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        return context.Response.WriteAsync(new BusinessProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://idrobe.com/probs/business",
            Title = "Business exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateValidationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        object errors = ((ValidationException)exception).Errors;

        return context.Response.WriteAsync(new Problems.ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://idrobe.com/probs/validation",
            Title = "Validation error(s)",
            Detail = "",
            Instance = "",
            Errors = errors
        }.ToString());
    }

    private async Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        var errorResponse = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://idrobe.com/probs/internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        };

        var errorResponseJson = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(errorResponseJson);

        //return context.Response.WriteAsync(new ProblemDetails
        //{
        //    Status = StatusCodes.Status500InternalServerError,
        //    Type = "https://idrobe.com/probs/internal",
        //    Title = "Internal exception",
        //    Detail = exception.Message,
        //    Instance = ""
        //}.ToString());
    }
}
