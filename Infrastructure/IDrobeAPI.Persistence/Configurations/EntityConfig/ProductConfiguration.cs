using Bogus;
using IDrobeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Configurations.EntityConfig
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x=>x.BrandId).IsRequired();
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(200);
            //builder.Property(x=>x.ArmType).HasMaxLength(200);
            //builder.Property(x=>x.ImagePath).HasMaxLength(200);
            //builder.Property(x=>x.StockQuantity).IsRequired();

            builder.HasQueryFilter(t => t.IsDeleted == false);//softdelete ucun fitir


            Faker faker = new("en");

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                //Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                ImagePath = faker.Image.LoremPixelUrl(),
                IsNew = true,
                Size = "M",
                Color = faker.Commerce.Color(),
                Length =  15.3m,
                ClothesType = "Nem",
                ArmType ="Nem2",
                CreatedDate = DateTime.Now,
                IsDeleted = false
                
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                //Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                ImagePath = faker.Image.LoremPixelUrl(),
                IsNew = true,
                Size = "M",
                Color = faker.Commerce.Color(),
                Length = 15.3m,
                ClothesType = "Nem",
                ArmType = "Nem2",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            builder.HasData(product1, product2);
        }
    }
}
