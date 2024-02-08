using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Application.Interfaces.Repositories
{                                                                                            //newlana bilinir
    public interface IWriteRepository<T> :IRepository<T> where T:EntityBase,IEntityBaseAble, new()
    {
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);

        bool Update(T entity);
        Task UpdateRange(ICollection<T> entities);

        bool HardDelete(T entity);
        Task HardDeleteRangeAsync(IList<T> entities);
        //Task<bool> HardRemove(string id);

        bool SoftDelete(T entity);
        Task SoftDeleteRangeAsync(IList<T> entities);
        //Task<bool> SoftRemove(string id);


    }
}
