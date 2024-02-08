using AutoMapper;
using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Features.Products.Commands.ProductCreatings;
using IDrobeAPI.Application.Features.Products.Commands.UpdateProducts;
using IDrobeAPI.Application.Features.Products.DTOs;
using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductCreateCommandRequest>()
            .ForMember(dest => dest.CategoryIds, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<Product, UpdateProductCommandRequest>()
            .ForMember(dest => dest.CategoryIds, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<Product, ProductGetDTO>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand)) 
            .ForMember(dest => dest.ProductCategories, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category)))
            .ReverseMap();

        CreateMap<Category, CategoryGetDto>().ReverseMap();

        CreateMap<Brand, BrandGetDto>().ReverseMap();

        CreateMap<IPaginate<Product>, ProductPaginationListViewModel>()
              .ReverseMap();

        CreateMap<ProductCreateCommandRequest, ProductCategory>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryIds))
            .ReverseMap();

    }
}
