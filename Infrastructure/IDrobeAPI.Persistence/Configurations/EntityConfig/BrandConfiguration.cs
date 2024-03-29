﻿using Bogus;
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
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.BrandName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.BrandType).HasMaxLength(30).IsRequired();

            Faker faker = new("en");

            Brand brand1 = new()
            {
                Id = 1,
                BrandName = faker.Commerce.Department(),
                BrandType = "Stores",
                CreatedDate = DateTime.Now,
                ImagePath = "/hjhsja",
                Description = faker.Commerce.ProductDescription(),
                IsDeleted = false
            };

            Brand brand2 = new()
            {
                Id = 2,
                BrandName = faker.Commerce.Department(),
                BrandType = "Stores",
                ImagePath = "/jhkl",
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            Brand brand3 = new()
            {
                Id = 3,
                BrandName = faker.Commerce.Department(),
                BrandType = "Brands",
                ImagePath = "/jjlkl",
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                IsDeleted = true
            };
            builder.HasData(brand1, brand2, brand3);

        }
    }
}
