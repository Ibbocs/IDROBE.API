using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Products.Constants;
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

namespace IDrobeAPI.Application.Features.Products.Commands.UpdateProducts;

public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, ActionResponse>
{
    private readonly ProductRules _productRules;
    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _productRules = productRules;
    }

    public async Task<ActionResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        ActionResponse response = new ActionResponse(false, System.Net.HttpStatusCode.BadRequest, "Bad Request");

        var oldProduct = await unitOfWork.GetReadRepository<Product>().GetSingleAsync(p => p.Id == request.Id, enableTracking:true, include: p=> p.Include(pc=> pc.ProductCategories));

        _productRules.ProductShouldExistWhenRequested(oldProduct, request.Id);

        await _productRules.BrandShouldBeExisted(request.BrandId);
        await _productRules.CategoriesShouldBeExisted(request.CategoryIds);

        var newProduct = mapper.Map(request, oldProduct);

        _productRules.ProductCanNotBeNull(newProduct);

        var resultForProduct = unitOfWork.GetWriteRepository<Product>().Update(newProduct);

        _productRules.ProductResultProblem(resultForProduct);

        //todo burda save elemek, sora categoryileri deyismek belke? ProductUpdate

        var oldCategoryIds = oldProduct.ProductCategories;
        foreach (var item in oldCategoryIds)
        {
            var oldProuctCategory = await unitOfWork.GetReadRepository<ProductCategory>().GetSingleAsync(pc => pc.CategoryId == item.CategoryId, enableTracking: true);

            //todo productCategoryCanNotBeNull ve CategoryId tekrarlana bilmez

            var resultForProductCategory = unitOfWork.GetWriteRepository<ProductCategory>().HardDelete(oldProuctCategory);

            _productRules.ProductCategoryResultProblem(resultForProductCategory, item.CategoryId);

        }

        var rowAffectForProduct = await unitOfWork.SaveAsync();

        _productRules.ProductRowAffectProblem(rowAffectForProduct);

        foreach (var item in request.CategoryIds)
        {
            var resultForProductCategory = await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
            {
                CategoryId = item,
                ProductId = oldProduct.Id,
            });

            _productRules.ProductCategoryResultProblem(resultForProductCategory, item);
        }

        var rowAffectForProductCategory = await unitOfWork.SaveAsync();
        _productRules.ProductCategoryRowAffectProblem(rowAffectForProductCategory);


        response.RequestSuccessful = true;
        response.ResponseCode = System.Net.HttpStatusCode.OK;
        response.Message = $"{request.Title} {ProductResponseMessageConstants.successfullyUpdated}";

        return response;
    }
}
