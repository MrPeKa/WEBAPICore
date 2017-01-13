using System;
using System.Linq.Expressions;
using AutoMapper;

namespace CoreWEBAPI.Helpers
{
    public static class MappingHelpers
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}