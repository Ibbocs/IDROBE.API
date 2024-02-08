using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Products.Constants;
using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Features.Products.Rules;
using IDrobeAPI.Application.Interfaces.IPagination;
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

namespace IDrobeAPI.Application.Features.Products.Queries.GetByPaginationAllProducts;

public class GetByPaginationProductsQueryHandler : BaseHandler,
    IRequestHandler<GetByPaginationProductsQueryRequest, GenericActionResponse<ProductPaginationListViewModel>>
{
    private readonly ProductRules _productRules;
    public GetByPaginationProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _productRules = productRules;
    }

    public async Task<GenericActionResponse<ProductPaginationListViewModel>> Handle(GetByPaginationProductsQueryRequest request, CancellationToken cancellationToken)
    {
        GenericActionResponse<ProductPaginationListViewModel> response =
         new GenericActionResponse<ProductPaginationListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

        //IPaginate<Product> data = await unitOfWork.GetReadRepository<Product>().GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        IPaginate<Product> data;
        if (request.isDeleted == true)
        {
            data = await unitOfWork.GetReadRepository<Product>().GetListAsync(
                index: request.PageRequest.Page, size: request.PageRequest.PageSize, isDeleted: true,
                include: p => p.Include(pc => pc.ProductCategories).ThenInclude(pc => pc.Category)
                .Include(b => b.Brand));
        }
        else
        {
            data = await unitOfWork.GetReadRepository<Product>().GetListAsync(
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                include: p => p.Include(pc => pc.ProductCategories).ThenInclude(pc => pc.Category)
                .Include(b => b.Brand));
        }

        //todo bunun ustunde dusun, null gondermek olsunmu usere? - GetByPaginationProductQueryHandler
        //bunu Brend ve Category de elave ele 
        //var product = data.Items; 
        //foreach (var item in product)
        //{
        //    _productRules.ProductShouldExistWhenRequested(item);
        //}

        var mappedData = mapper.Map<ProductPaginationListViewModel>(data);

        response.Data = mappedData;
        response.RequestSuccessful = true;
        response.Message = $"{ProductResponseMessageConstants.successfullyGetAll}";
        response.ResponseCode = System.Net.HttpStatusCode.OK;

        return response;
    }
}
