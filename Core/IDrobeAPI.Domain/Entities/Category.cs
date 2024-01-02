using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Domain.Entities
{
    public class Category:EntityBase
    {
        public Category()
        {

        }
        public Category(int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }
        public int ParentId { get; set; }//Electronic en boyuk categorydi 0 olur bu id, amma kompda ve printerde bu Electronic idsi olur. Sub category idare elemek olur bu sayede
        public string Name { get; set; }
        public int Priorty { get; set; }//Electronic cat. olan kompun priorty 1 olur, amma printerin 2 meselen
        public ICollection<CategoryDetail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }

    public class CategoryDetail : EntityBase
    {
        //her category'de ferli xusiyyetler ola biler: Kompda ram - yaddas olanda, geyimde reng-beden ola biler meselen
        public CategoryDetail()
        {

        }
        public CategoryDetail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Brand : EntityBase
    {
        public Brand()
        {
        }
        public Brand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class Product : EntityBase, ISoftDeleteAble
    {

        public Product()
        {

        }

        public Product(string title, string description, int brandId, decimal price, decimal discount, int stockQuantity)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
            StockQuantity = stockQuantity;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int StockQuantity { get; set; }

        public Brand Brand { get; set; }

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

        public ProductCategory(int productId, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }

    public class Order : EntityBase,ISoftDeleteAble
    {
        public Order()
        {
            
        }

        public Order(DateTime orderDate, decimal totalAmount, string userId)
        {
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            UserId = userId;
        }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class OrderDetails : EntityBase,ISoftDeleteAble
    {
        public OrderDetails()
        {
            
        }

        public OrderDetails(int quantity, decimal subtotal, int orderId, int productId)
        {
            Quantity = quantity;
            Subtotal = subtotal;
            OrderId = orderId;
            ProductId = productId;
        }

        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        // Relation
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Favorite : EntityBase
    {
        public Favorite()
        {
            
        }

        public Favorite(string userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }



        // Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

}
