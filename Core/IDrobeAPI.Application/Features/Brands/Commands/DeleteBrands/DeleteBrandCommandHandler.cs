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

namespace IDrobeAPI.Application.Features.Brands.Commands.DeleteBrands;

public class DeleteBrandCommandHandler : BaseHandler, IRequestHandler<DeleteBrandCommandRequest, ActionResponse>
{
    private readonly BrandRules _brandRules;
    public DeleteBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<ActionResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        Brand deletedData = await unitOfWork.GetReadRepository<Brand>().GetSingleAsync(id => id.Id == request.Id, enableTracking: true);
        _brandRules.BrandShouldExistWhenRequested(deletedData);

        bool result = unitOfWork.GetWriteRepository<Brand>().HardDelete(deletedData);
        _brandRules.BrandResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        _brandRules.BrandRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Message = $"{deletedData.BrandName} {BrandResponseMessageConstants.successfullyDeleted}";

        return response;
    }
}
