﻿using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryPaginations;
using IDrobeAPI.Application.Features.Categories.Rules;
using IDrobeAPI.Application.Interfaces.IPagination;
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

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryDynamics;

public class GetListCategoryByDynamicQueryHandler : BaseHandler, 
    IRequestHandler<GetListCategoryByDynamicQueryRequest, GenericActionResponse<CategoryPaginationListViewModel>>
{
    private readonly CategoryRules _categoryRules;
    public GetListCategoryByDynamicQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _categoryRules = categoryRules;
    }

    public async Task<GenericActionResponse<CategoryPaginationListViewModel>> Handle(GetListCategoryByDynamicQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<CategoryPaginationListViewModel> response =
          new GenericActionResponse<CategoryPaginationListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        IPaginate<Category> data = await unitOfWork.GetReadRepository<Category>().GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var mappedData = mapper.Map<CategoryPaginationListViewModel>(data);

        response.Data = mappedData;
        response.RequestSuccessful = true;
        response.Message = $"{CategoryResponseMessageConstants.successfullyGetAll}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
