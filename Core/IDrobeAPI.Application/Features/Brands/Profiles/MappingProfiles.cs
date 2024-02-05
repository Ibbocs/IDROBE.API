using AutoMapper;
using IDrobeAPI.Application.Features.Brands.Commands.CreateBrands;
using IDrobeAPI.Application.Features.Brands.Commands.UpdateBrands;
using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Features.Brands.Models;
using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommandRequest>()
                .ReverseMap();

        CreateMap<Brand, UpdateBrandCommandRequest>()
            .ReverseMap();

        CreateMap<Brand, BrandGetDto>()
            .ReverseMap();

        CreateMap<IPaginate<Brand>, BrandPaginationListViewModel>()
            .ReverseMap();
    }
}
