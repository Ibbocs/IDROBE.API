using IDrobeAPI.Domain.Entities;
using IDrobeAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Configurations.EntityConfig
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=>x.FirstName).HasMaxLength(50);
            builder.Property(x=>x.LastName).HasMaxLength(50);
        }
    }
}
