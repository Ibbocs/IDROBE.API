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

namespace IDrobeAPI.Application.Features.Brands.Commands.UpdateBrands;

public class UpdateBrandCommandHandler : BaseHandler, IRequestHandler<UpdateBrandCommandRequest, ActionResponse>
{
    private readonly BrandRules _brandRules;
    public UpdateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<ActionResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        Brand oldData = await unitOfWork.GetReadRepository<Brand>().GetSingleAsync(id => id.Id == request.Id, enableTracking: true);
        //category var/yox
        _brandRules.BrandShouldExistWhenRequested(oldData);

        var newData = mapper.Map(request, oldData);

        _brandRules.EntityCanNotBeNull(newData);

        bool result = unitOfWork.GetWriteRepository<Brand>().Update(newData);
        //update olmagi
        _brandRules.BrandResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        //db dusmeyi
        _brandRules.BrandRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Message = $"{oldData.BrandName} {BrandResponseMessageConstants.successfullyUpdated}";//todo burda teze name de ola bilerdi - UpdateBrandCommandHandler

        return response;
    }
}
