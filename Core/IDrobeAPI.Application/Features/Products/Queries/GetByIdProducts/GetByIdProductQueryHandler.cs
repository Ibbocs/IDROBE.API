using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Products.Constants;
using IDrobeAPI.Application.Features.Products.DTOs;
using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Features.Products.Rules;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByIdProducts;

public class GetByIdProductQueryHandler : BaseHandler, IRequestHandler<GetByIdProductQueryRequest, GenericActionResponse<ProductSingleViewModel>>
{
    private readonly ProductRules _productRules;
    public GetByIdProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _productRules = productRules;
    }

    public async Task<GenericActionResponse<ProductSingleViewModel>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<ProductSingleViewModel> response =
        new GenericActionResponse<ProductSingleViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        //Product data = await unitOfWork.GetReadRepository<Product>().GetSingleAsync(x => x.Id == request.Id);

        Product data = new();
        if (request.isDeleted == true)
        {
            data = await unitOfWork.GetReadRepository<Product>().GetSingleAsync( p=>p.Id == request.Id,
                isDeleted: true,
                include: p => p.Include(pc => pc.ProductCategories).ThenInclude(pc => pc.Category)
                .Include(b => b.Brand));
        }
        else
        {
            data = await unitOfWork.GetReadRepository<Product>().GetSingleAsync(p => p.Id == request.Id,
                include: p => p.Include(pc => pc.ProductCategories).ThenInclude(pc => pc.Category)
                .Include(b => b.Brand));
        }

        _productRules.ProductShouldExistWhenRequested(data, request.Id);

        var mappedData = mapper.Map<ProductGetDTO>(data);


        response.Data = new() { Items = mappedData };
        response.RequestSuccessful = true;
        response.Message = $"Id: {request.Id} - {ProductResponseMessageConstants.successfullyGetSingle}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
