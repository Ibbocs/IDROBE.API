using IDrobeAPI.Application.Features.Brands.DTOs;
using IDrobeAPI.Application.Models.Responses;
using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Entities;
using MediatR;

namespace IDrobeAPI.API;

public class Product : EntityBase, ISoftDeleteAble
{

    public Product()
    {

    }

    public Product(string title, string description, int brandId, decimal price, string ımagePath, bool ısNew, string size, string color, decimal length, string clothesType, string armType) : this()
    {
        Title = title;
        Description = description;
        BrandId = brandId;
        Price = price;
        ImagePath = ımagePath;
        IsNew = ısNew;
        Size = size;
        Color = color;
        Length = length;
        ClothesType = clothesType;
        ArmType = armType;

        //Discount = discount;
        //StockQuantity = stockQuantity;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public bool IsNew { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public decimal Length { get; set; }
    public string ClothesType { get; set; }
    public string ArmType { get; set; }

    //public decimal Discount { get; set; }
    //public int StockQuantity { get; set; }

    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    //public required string ImagePath { get; set; }
}

public class ProductCategory : IEntityBaseAble
{
    //productun birden cox categorysi ola biler. Messelen bir komp hem komp hem de electronics kategorisinde ola biler
    public ProductCategory()
    {

    }

    public ProductCategory(int productId, int categoryId) : this()
    {
        ProductId = productId;
        CategoryId = categoryId;
    }

    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public virtual Product Product { get; set; }
    public virtual Category Category { get; set; }
}


public class Category : EntityBase
{
    public Category()
    {

    }
    public Category(int parentId, string name, int priorty) : this()
    {
        ParentId = parentId;
        CategoryName = name;
        Priorty = priorty;
    }
    public int ParentId { get; set; }//Electronic en boyuk categorydi 0 olur bu id, amma kompda ve printerde bu Electronic idsi olur. Sub category idare elemek olur bu sayede
    public string CategoryName { get; set; }
    public int Priorty { get; set; }//Electronic cat. olan kompun priorty 1 olur, amma printerin 2 meselen
    public ICollection<CategoryDetail> Details { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}

public class ProductGetDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public bool IsNew { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public decimal Length { get; set; }
    public string ClothesType { get; set; }
    public string ArmType { get; set; }
    //bunun adin Brand yazmagimin sebebi mapper basa dusun deyedi, entity icindeki ile eyni olmalidi
    public BrandGetDto Brand { get; set; }
    public IList<ProductCategoryGetDTO> ProductCategories { get; set; }
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

public class BrandGetDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public string BrandType { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    //burda inculud elesem eger hansisa entity dtosun, onda entity adin yazmaliyam mapper gore
}
