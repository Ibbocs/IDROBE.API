using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Brands.Constants;
using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Features.Brands.Models;
using IDrobeAPI.Application.Features.Brands.Rules;
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

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandQueryHandler : BaseHandler, IRequestHandler<GetAllBrandQueryRequest, GenericActionResponse<BrandListViewModel>>
{
    private readonly BrandRules _brandRules;
    public GetAllBrandQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<GenericActionResponse<BrandListViewModel>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<BrandListViewModel> response =
            new GenericActionResponse<BrandListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        IList<Brand> data = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();

        var mappedData = mapper.Map<IList<BrandGetDto>>(data);

        response.Data = new() { Items = mappedData };
        response.RequestSuccessful = true;
        response.Message = $"{BrandResponseMessageConstants.successfullyGetAll}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
