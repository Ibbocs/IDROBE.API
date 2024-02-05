using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Features.Categories.Rules;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetByIdCategories;

public class GetByIdCategoryQueryHandler : BaseHandler, IRequestHandler<GetByIdCategoryQueryRequest, GenericActionResponse<CategorySingleViewModel>>
{
    private readonly CategoryRules _categoryRules;

    public GetByIdCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _categoryRules = categoryRules;
    }

    public async Task<GenericActionResponse<CategorySingleViewModel>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<CategorySingleViewModel> response =
        new GenericActionResponse<CategorySingleViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        Category data = await unitOfWork.GetReadRepository<Category>().GetSingleAsync(x=>x.Id == request.Id);

        _categoryRules.CategoryShouldExistWhenRequested(data);

        var mappedData = mapper.Map<CategoryGetDto>(data);


        response.Data = new() { Items = mappedData };
        response.RequestSuccessful = true;
        response.Message = $"Id: {request.Id} - {CategoryResponseMessageConstants.successfullyGetSingle}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
