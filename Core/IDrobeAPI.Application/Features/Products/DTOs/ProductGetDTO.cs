using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.DTOs;

public class ProductGetDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public bool IsNew { get; set; }
    public bool IsDeleted { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public decimal Length { get; set; }
    public string ClothesType { get; set; }
    public string ArmType { get; set; }
    //bunun adin Brand yazmagimin sebebi mapper basa dusun deyedi, entity icindeki ile eyni olmalidi
    public BrandGetDto Brand { get; set; }
    public IList<CategoryGetDto> Category { get; set; }
}

public class ProductCategoryGetDTO
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string CategoryName { get; set; }
    public int Priorty { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
