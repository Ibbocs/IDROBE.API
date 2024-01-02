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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();

            builder.HasQueryFilter(t => t.IsDeleted == false);//softdelete ucun fitir

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
