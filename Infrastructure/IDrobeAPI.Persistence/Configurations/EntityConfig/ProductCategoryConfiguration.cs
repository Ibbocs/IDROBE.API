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
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x=>x.ProductId).IsRequired();
            builder.Property(x=>x.CategoryId).IsRequired();
            builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.UpdateDate);
            builder.Ignore(x => x.CreatedDate);
            builder.Ignore(x => x.Id);



            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
