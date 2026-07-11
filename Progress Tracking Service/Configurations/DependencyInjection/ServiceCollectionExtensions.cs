using ProgressTrackingService.Common.BaseHandler;
using ProgressTrackingService.Common.Helpers;
using ProgressTrackingService.Common.Middlewares;
using ProgressTrackingService.Common.Services;
using ProgressTrackingService.Data.Contexts;

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpContextAccessor(); // Required for CurrentUserService to work!
            services.AddScoped<CurrentUserService>();
            services.AddScoped<BaseParameters>();
            services.AddScoped<EnumLookupCache>();
            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<ValidationExceptionHandlingMiddleware>();

            // Register the standard IdGen Snowflake ID Generator (originally developed by Twitter)
            // Generator ID 0 is used as the machine/worker ID.
            services.AddSingleton<IdGen.IIdGenerator<long>>(x => new IdGen.IdGenerator(0));


            return services;
        }
    }
}
