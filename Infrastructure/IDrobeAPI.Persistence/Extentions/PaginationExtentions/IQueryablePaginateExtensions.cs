﻿using IDrobeAPI.Application.Interfaces.IPagination;
using IDrobeAPI.Persistence.Implementation.Paginations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Extentions.PaginationExtentions
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size,
                                                                  int from = 0,
                                                                  CancellationToken cancellationToken = default)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            List<T> items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken)
                                        .ConfigureAwait(false);
            Application.Interfaces.IPagination.Paginate<T> list = new()
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size) //3 data var ve 2 data 1 seyfede gostere bilerem, onda 2 seyfem olacagini 3/2 cvbin uste yuvarlayaraq ede bilerem, ceilling de uste yuvarlama ucundu.
            };
            return list;
        }


        public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size,
                                                 int from = 0)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

            int count = source.Count();
            List<T> items = source.Skip((index - from) * size).Take(size).ToList();
            Application.Interfaces.IPagination.Paginate<T> list = new()
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };
            return list;
        }
    }
}
