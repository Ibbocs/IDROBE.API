using IDrobeAPI.Application.Interfaces.Repositories;
using IDrobeAPI.Domain.Common;
using IDrobeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Implementation.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase, IEntityBaseAble, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbSet<T> Table => dbContext.Set<T>();

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, bool isDeleted = false)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            queryable = queryable.AsNoTracking();
            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
            if (predicate is not null) queryable.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> FindQuery(Expression<Func<T, bool>> predicate, bool enableTracking = false, bool isDeleted = false)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
            return queryable.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, bool isDeleted = false)
        {
            IQueryable<T> queryable = Table/*.AsQueryable()*/;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, bool isDeleted = false,
            int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null, bool enableTracking = false, bool isDeleted = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (isDeleted) queryable = queryable.IgnoreQueryFilters();
            if (include is not null) queryable = include(queryable);

            //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }
    }
}
