using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Features.Categories.Rules;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoryQueryHandler : BaseHandler,
    IRequestHandler<GetAllCategoryQueryRequest, GenericActionResponse<CategoryListViewModel>>
{
    private readonly CategoryRules _categoryRules;
    public GetAllCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _categoryRules = categoryRules;
    }

    public async Task<GenericActionResponse<CategoryListViewModel>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<CategoryListViewModel> response =
            new GenericActionResponse<CategoryListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        IList<Category> data = await unitOfWork.GetReadRepository<Category>().GetAllAsync();

        var mappedData = mapper.Map<IList<CategoryGetDto>>(data);

        response.Data = new() { Items = mappedData };
        response.RequestSuccessful = true;
        response.Message = $"{CategoryResponseMessageConstants.successfullyGetAll}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
