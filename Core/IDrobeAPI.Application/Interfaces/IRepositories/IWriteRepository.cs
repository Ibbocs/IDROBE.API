using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Application.Interfaces.Repositories
{                                                                                            //newlana bilinir
    public interface IWriteRepository<T> :IRepository<T> where T:EntityBase,IEntityBaseAble, new()
    {
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);

        Task<bool> UpdateAsync(T entity);
        Task UpdateRange(ICollection<T> entities);

        Task<bool> HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entities);
        //Task<bool> HardRemove(string id);

        Task<bool> SoftDeleteAsync(T entity);
        Task SoftDeleteRangeAsync(IList<T> entities);
        //Task<bool> SoftRemove(string id);


    }
}
