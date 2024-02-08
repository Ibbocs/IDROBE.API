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

namespace IDrobeAPI.Application.Features.Products.Commands.ProductCreatings;

public class ProductCreateCommandHandler : BaseHandler, IRequestHandler<ProductCreateCommandRequest, ActionResponse>
{
    private readonly ProductRules _productRules;
    public ProductCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _productRules = productRules;
    }

    public async Task<ActionResponse> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

       await _productRules.BrandShouldBeExisted(request.BrandId);
       await _productRules.CategoriesShouldBeExisted(request.CategoryIds);

        var newProduct = mapper.Map<Product>(request);

        _productRules.ProductCanNotBeNull(newProduct);

        var resultForProduct = await unitOfWork.GetWriteRepository<Product>().AddAsync(newProduct);

        _productRules.ProductResultProblem(resultForProduct);

        var rowAffectForProduct = await unitOfWork.SaveAsync();

        _productRules.ProductRowAffectProblem(rowAffectForProduct);

        var lestAddedProduct = (await unitOfWork.GetReadRepository<Product>().GetAllAsync(orderBy: q => q.OrderByDescending(p => p.CreatedDate))).FirstOrDefault();

        //burda rule il gelen data ile requestedkinin propertilerin check ede bilerem...

        //database elave edilen product tapmaliyam...

        foreach (var item in request.CategoryIds)
        {
            var resultForProductCategory = await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
            {
                CategoryId = item,
                ProductId = lestAddedProduct.Id,
            });

            _productRules.ProductCategoryResultProblem(resultForProductCategory, item);
        }

        var rowAffectForProductCategory = await unitOfWork.SaveAsync();
        _productRules.ProductCategoryRowAffectProblem(rowAffectForProductCategory);


        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.Created;
        response.Message = $"{request.Title} {ProductResponseMessageConstants.successfullyCreated}";

        return response;
    }
}
