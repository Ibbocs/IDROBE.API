using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace IDrobeAPI.Application.Atributs;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        var validators = serviceProvider.GetServices<IValidator>();

        foreach (var validator in validators)
        {
            var modelType = validator.GetType().BaseType.GetGenericArguments().FirstOrDefault();
            if (modelType != null)
            {
                var model = context.ActionArguments.Values.FirstOrDefault(arg => arg.GetType() == modelType);
                if (model != null)
                {
                    //var validationResult = validator.Validate(model);
                    //if (!validationResult.IsValid)
                    //{
                    //    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    //    context.Result = new BadRequestObjectResult(errors);
                    //    return;
                    //}
                }
            }
        }

        base.OnActionExecuting(context);
    }
}
