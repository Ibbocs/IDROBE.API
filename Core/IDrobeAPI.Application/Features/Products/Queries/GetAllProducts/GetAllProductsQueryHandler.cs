using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Features.Products.Constants;
using IDrobeAPI.Application.Features.Products.DTOs;
using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Features.Products.Rules;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
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

namespace IDrobeAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : BaseHandler, IRequestHandler<GetAllProductsQueryRequest, GenericActionResponse<ProductListViewModel>>
    {

        //public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

        //    //include ile gelen brand tipinde data, branddto cevrilir cunki o da QueryResponse icinde yeniden cevrilmede lazimdir.
        //    var brand = mapper.Map<BrandGetDto, Brand>(new Brand());

        //    var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
        //    foreach (var item in map)
        //        item.Price -= (item.Price * item.Discount / 100);

        //    return map;
        //}
        private readonly ProductRules _productRules;
        public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<GenericActionResponse<ProductListViewModel>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            GenericActionResponse<ProductListViewModel> response =
            new GenericActionResponse<ProductListViewModel>(false, System.Net.HttpStatusCode.BadRequest, null, "Bad Request");

            IList<Product> data = new List<Product>();
            if (request.isDeleted == true)
            {
                data = await unitOfWork.GetReadRepository<Product>().GetAllAsync(isDeleted:true, 
                    include: p=> p.Include(pc=> pc.ProductCategories).ThenInclude(pc=>pc.Category)
                    .Include(b=>b.Brand));
            }
            else
            {
                data = await unitOfWork.GetReadRepository<Product>().GetAllAsync(
                    include: p => p.Include(pc => pc.ProductCategories).ThenInclude(pc => pc.Category)
                    .Include(b => b.Brand));
            }
            

            var mappedData = mapper.Map<IList<ProductGetDTO>>(data);

            response.Data = new() { Items = mappedData };
            response.RequestSuccessful = true;
            response.Message = $"{ProductResponseMessageConstants.successfullyGetAll}";
            response.ResponseCode = System.Net.HttpStatusCode.OK;

            return response;
        }
    }
}
