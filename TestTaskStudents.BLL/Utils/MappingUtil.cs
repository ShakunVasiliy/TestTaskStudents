using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using AutoMapper; 

namespace TestTaskStudents.BLL.Utils
{
    public static class MappingUtil
    {
        public static void CreateMap<TSource, TTarget>()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TTarget>());
        }

        public static TTarget MapToInstance<TSource, TTarget>(TSource source)
        {
            CreateMap<TSource, TTarget>();

            return Mapper.Map<TSource, TTarget>(source);
        }

        public static ObservableCollection<TTarget> MapToObservebleCollection<TSource, TTarget>(IEnumerable<TSource> sourceCollection)
        {
            CreateMap<TSource, TTarget>();

            return Mapper.Map<IEnumerable<TSource>, ObservableCollection<TTarget>>(sourceCollection);
        }
    }
}
