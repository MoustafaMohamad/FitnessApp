using Mapster;
using MapsterMapper;

namespace Workout_Exercise_Catalog.Configurations.DependencyInjection
{
    public static class MapsterConfiguration
    {
        public static IServiceCollection AddMapsterConfig(this IServiceCollection services, Type type)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(type.Assembly);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
