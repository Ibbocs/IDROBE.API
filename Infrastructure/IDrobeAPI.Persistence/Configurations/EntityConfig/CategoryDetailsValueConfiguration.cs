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
    public class CategoryDetailsValueConfiguration : IEntityTypeConfiguration<CategoryDetailsValue>
    {
        public void Configure(EntityTypeBuilder<CategoryDetailsValue> builder)
        {
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.CategoryDetailId).IsRequired();
            builder.Property(x => x.Value).IsRequired().HasMaxLength(100);
        }
    }
}
