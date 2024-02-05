using AutoMapper;
using IDrobeAPI.Application.Features.Categories.Commands.CreateCategories;
using IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryCommandRequest>()
                .ReverseMap();

            CreateMap<Category, UpdateCategoryCommandRequest>()
                .ReverseMap();

            CreateMap<Category, CategoryGetDto>()
                .ReverseMap();
            
            CreateMap<IPaginate<Category>, CategoryPaginationListViewModel>()
                .ReverseMap();



        }
    }
}
