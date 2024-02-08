using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Products.Constants;
using IDrobeAPI.Application.Features.Products.Rules;
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

namespace IDrobeAPI.Application.Features.Products.Commands.DeleteProducts;

public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, ActionResponse>
{
    private readonly ProductRules _productRules;
    public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _productRules = productRules;
    }

    public async Task<ActionResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        Product deletedData = await unitOfWork.GetReadRepository<Product>().GetSingleAsync(id => id.Id == request.Id, enableTracking: true);
        _productRules.ProductShouldExistWhenRequested(deletedData, request.Id);

        bool result = unitOfWork.GetWriteRepository<Product>().SoftDelete(deletedData);
        _productRules.ProductResultProblem(result);

        int rowAffect = await unitOfWork.SaveAsync();
        _productRules.ProductRowAffectProblem(rowAffect);

        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Message = $"{deletedData.Title} {ProductResponseMessageConstants.successfullyDeleted}";

        return response;
    }
}
