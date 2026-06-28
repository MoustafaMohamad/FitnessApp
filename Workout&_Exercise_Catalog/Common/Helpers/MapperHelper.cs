

       using Mapster;
using MapsterMapper;
using System.Collections;
namespace Workout_Exercise_Catalog.Common.Helpers
    {
        public static class MapperHelper
        {
            public static IMapper Mapper { get; set; }

            public static IQueryable<TResult> Map<TResult>(this IQueryable source)
            {
                return source.ProjectToType<TResult>();
            }

            public static IEnumerable<TResult> Map<TResult>(this IEnumerable source)
            {
                return source.Cast<object>().Adapt<IEnumerable<TResult>>();
            }

            public static TResult MapOne<TResult>(this object source)
            {
                return source.Adapt<TResult>();
            }
        }
    }


