﻿using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Application.Models.DynamicQueriesModels;
using IDrobeAPI.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.Repositories;
                                                                                           //newlana bilinir
public interface IReadRepository<T> : IRepository<T> where T : EntityBase, IEntityBaseAble, new()
{
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,//Where serti elave ede bilmek ucun
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,//include ve theninclude elave ede bilmek ucun
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,//order elave ede bilmek ucun
        bool enableTracking = false, bool isDeleted = false);

    Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false, bool isDeleted = false, int currentPage = 1, int pageSize = 3);

    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false, bool isDeleted = false);

    IQueryable<T> FindQuery(Expression<Func<T, bool>> predicate, bool enableTracking = false, 
        bool isDeleted = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, bool isDeleted = false);

    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                               Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                               Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                               int index = 0, int size = 10, bool enableTracking = false, 
                               bool isDeleted = false,
                               CancellationToken cancellationToken = default);

    Task<IPaginate<T>> GetListByDynamicAsync(Dynamic dynamic,
                                        Func<IQueryable<T>, 
                                        IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = false, 
                                        bool isDeleted = false,
                                        CancellationToken cancellationToken = default);

    //getbyid de yazmaq olar amma getsibgle o isi gorur

    //public IQueryable<T> FindByDynamicQueryAsync(Dynamic dynamic, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = false, bool isDeleted = false, CancellationToken cancellationToken = default);

    //public Task<IPaginate<T>> GetByDynamicAsPaginationAsync(IQueryable<T> queryable, int index = 0, int size = 10, CancellationToken cancellationToken = default);

    //public IQueryable<T> AddNewDynamicQueryAsync(Dynamic dynamic, IQueryable<T> queryable);


}
