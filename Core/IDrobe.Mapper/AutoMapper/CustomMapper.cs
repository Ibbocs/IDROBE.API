using AutoMapper;
using AutoMapper.Internal;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobe.Mapper.AutoMapper;

public class CustomMapper : ICustomMapper
{
    public static List<TypePair> typePairs = new();
    private IMapper MapperContainer;

    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);

        return MapperContainer.Map<TSource, TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);

        return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);

        return MapperContainer.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        Config<TDestination, IList<object>>(5, ignore);

        return MapperContainer.Map<IList<TDestination>>(source);
    }

    //dept yeni entity icinde bir baska entity olmasi
    protected void Config<TDestionation, TSource>(int depth = 5, string? ignore = null, Dictionary<string, string>? mapFrom = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestionation));//typePaire yaradiriq gelen dto ve entiy esasen meselen

        if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
            return;

        typePairs.Add(typePair);//typePaire elave edirik gelen dto ve entiy meselen

        var config = new MapperConfiguration(cfg =>
        {
            foreach (var item in typePairs)
            {
                //var mapExpression = cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth);
                //var config = new MapperConfiguration(cfg =>
                //{
                //    foreach (var item in typePairs)
                //    {
                //        var mapExpression = cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth);

                //        if (ignore is not null)
                //            mapExpression.ForMember(ignore, x => x.Ignore());

                //        if (mapFrom is not null)
                //        {
                //            foreach (var mapping in mapFrom)
                //            {
                //                mapExpression.ForMember(mapping.Key, opt => opt.MapFrom(mapping.Value));
                //            }
                //        }

                //        mapExpression.ReverseMap();
                //    }
                //});

                if (ignore is not null)
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                else
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
            }
        });

        MapperContainer = config.CreateMapper();
    }
}
