using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Brands.Constants;
using IDrobeAPI.Application.Features.Brands.Models;
using IDrobeAPI.Application.Features.Brands.Rules;
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

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandDynamic;

public class GetBrandByDynamicQueryHandler : BaseHandler, IRequestHandler<GetBrandByDynamicQueryRequest, GenericActionResponse<BrandPaginationListViewModel>>
{
    private readonly BrandRules _brandRules;
    public GetBrandByDynamicQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<GenericActionResponse<BrandPaginationListViewModel>> Handle(GetBrandByDynamicQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<BrandPaginationListViewModel> response =
           new GenericActionResponse<BrandPaginationListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        IPaginate<Brand> data = await unitOfWork.GetReadRepository<Brand>().GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var mappedData = mapper.Map<BrandPaginationListViewModel>(data);

        response.Data = mappedData;
        response.RequestSuccessful = true;
        response.Message = $"{BrandResponseMessageConstants.successfullyGetAll}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
