﻿using AutoMapper;

namespace BulgarianCreators.Web.Mapping
{
    public class MapperAdapter : IMapperAdapter
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}