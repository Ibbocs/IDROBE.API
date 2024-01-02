using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Interfaces.Repositories;
using IDrobeAPI.Domain.Common;
using IDrobeAPI.Persistence.Context;
using IDrobeAPI.Persistence.Implementation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Implementation.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public IReadRepository<T> GetReadRepository<T>() where T : EntityBase, IEntityBaseAble, new() => new ReadRepository<T>(dbContext);
        public IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase, IEntityBaseAble, new() => new WriteRepository<T>(dbContext);

        public int Save() => dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
      
    }
}
