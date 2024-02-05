using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Brands.Constants;
using IDrobeAPI.Application.Features.Brands.Rules;
using IDrobeAPI.Application.Features.Categories.Constants;
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

namespace IDrobeAPI.Application.Features.Brands.Commands.CreateBrands;

public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, ActionResponse>
{
    private readonly BrandRules _brandRules;
    public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<ActionResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        var entity = mapper.Map<Brand>(request);

        _brandRules.EntityCanNotBeNull(entity);
        await _brandRules.BrandNameCanNotBeDuplicatedWhenInserted(request.BrandName);

        var result = await unitOfWork.GetWriteRepository<Brand>().AddAsync(entity);
        //result yoxla
        _brandRules.BrandResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        //rowaffect yoxla
        _brandRules.BrandRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.Created;
        response.Message = $"{request.BrandName} {BrandResponseMessageConstants.successfullyCreated}";

        return response;
    }
}
