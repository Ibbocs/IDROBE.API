using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Entities;
using IDrobeAPI.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Configleri elave etdim
            //builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.Now;
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdateDate = DateTime.Now;
                }
                else if (data.State == EntityState.Deleted && data.Entity is ISoftDeleteAble)//todo burda data ola da biler
                {
                    data.State = EntityState.Modified;
                    data.Entity.IsDeleted = true;
                }
                ////discard ile geri nese dondermirik
                //_ = data.State switch
                //{
                //    EntityState.Added => data.Entity.CreateDate = DateTime.Now,
                //    EntityState.Modified => data.Entity.UpdateDate = DateTime.Now,
                //    _ => DateTime.Now
                //    //EntityState.Deleted => data.Entity.IsDeleted = false
                //};
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
