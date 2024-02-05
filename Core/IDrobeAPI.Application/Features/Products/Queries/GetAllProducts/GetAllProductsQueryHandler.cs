using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICustomMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, ICustomMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

            //include ile gelen brand tipinde data, branddto cevrilir cunki o da QueryResponse icinde yeniden cevrilmede lazimdir.
            var brand = mapper.Map<BrandGetDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;
        }
    }
}
