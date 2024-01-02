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
    internal class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();

            builder.HasQueryFilter(t => t.IsDeleted == false);//softdelete ucun fitir

            builder.HasKey(x => new { x.ProductId, x.OrderId });

            builder.HasOne(p => p.Product)
               .WithMany(pc => pc.OrderDetails)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c => c.Order)
                .WithMany(pc => pc.OrderDetails)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
