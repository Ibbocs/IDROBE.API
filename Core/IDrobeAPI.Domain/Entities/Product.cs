using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class Product : EntityBase, ISoftDeleteAble
    {

        public Product()
        {

        }

        public Product(string title, string description, int brandId, decimal price, decimal discount, int stockQuantity) : this()
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

        public virtual Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        //public required string ImagePath { get; set; }
    }

}
