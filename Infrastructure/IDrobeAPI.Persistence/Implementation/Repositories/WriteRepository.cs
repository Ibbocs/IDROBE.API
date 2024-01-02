using IDrobeAPI.Application.Interfaces.Repositories;
using IDrobeAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Implementation.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase, IEntityBaseAble, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<T> Table => dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = null;
            await Task.Run(() => { entityEntry = Table.Update(entity); });
            return entityEntry==null ? false  : entityEntry.State == EntityState.Modified; 
        }

        public async Task UpdateRange(ICollection<T> entities)
        {
            await Task.Run(() => { Table.UpdateRange(entities); });
        }

        public async Task<bool> HardDeleteAsync(T entity)
        {
            EntityEntry<T> entityEntry = null;
            await Task.Run(() => { entityEntry = Table.Remove(entity); });
            return entityEntry == null ? false : entityEntry.State == EntityState.Modified;
        }

        public async Task HardDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => { Table.RemoveRange(entities); });
        }

        public async Task<bool> SoftDeleteAsync(T entity)
        {
            EntityEntry<T> entityEntry = null;
            entity.IsDeleted = true;
            await Task.Run(() => { entityEntry = Table.Update(entity); });
            return entityEntry == null ? false : entityEntry.State == EntityState.Modified;
        }

        public async Task SoftDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() =>
            {
                List<T> entityList = new();
                foreach (var item in entities)
                {
                    item.IsDeleted = true;
                    entityList.Add(item);
                }
                Table.UpdateRange(entityList);
            });
        }

        //public async Task<bool> SoftRemove(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> HardRemove(string id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
