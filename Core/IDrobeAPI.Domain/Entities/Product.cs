using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
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

}
