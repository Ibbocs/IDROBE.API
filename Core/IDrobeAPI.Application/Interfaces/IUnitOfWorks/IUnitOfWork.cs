using IDrobeAPI.Application.Interfaces.Repositories;
using IDrobeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.IUnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : EntityBase, IEntityBaseAble, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase, IEntityBaseAble, new();
        Task<int> SaveAsync();
        int Save();
    }
}
