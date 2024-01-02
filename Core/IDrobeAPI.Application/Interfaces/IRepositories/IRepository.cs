using IDrobeAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace IDrobeAPI.Application.Interfaces.Repositories
{                                                          //newlana bilinir
    public interface IRepository<T> where T :  EntityBase, new()
    {
        DbSet<T> Table { get; }
    }
}
