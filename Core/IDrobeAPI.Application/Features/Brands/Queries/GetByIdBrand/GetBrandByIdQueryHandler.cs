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

namespace IDrobeAPI.Application.Features.Brands.Queries.GetByIdBrand;

public class GetBrandByIdQueryHandler : BaseHandler, IRequestHandler<GetBrandByIdQueryRequest, GenericActionResponse<BrandSingleViewModel>>
{
    private readonly BrandRules _brandRules;
    public GetBrandByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<GenericActionResponse<BrandSingleViewModel>> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<BrandSingleViewModel> response =
        new GenericActionResponse<BrandSingleViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        Brand data = await unitOfWork.GetReadRepository<Brand>().GetSingleAsync(x => x.Id == request.Id);

        _brandRules.BrandShouldExistWhenRequested(data);

        var mappedData = mapper.Map<BrandGetDto>(data);


        response.Data = new() { Items = mappedData };
        response.RequestSuccessful = true;
        response.Message = $"Id: {request.Id} - {BrandResponseMessageConstants.successfullyGetSingle}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
