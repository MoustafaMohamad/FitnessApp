using FitnessCalculationEngine.Common.Helpers;
using FitnessCalculationEngine.Common.Middlewares;
using FitnessCalculationEngine.Data.Contexts;

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped<FitnessCalculationEngine.Common.Services.ICurrentUserService, FitnessCalculationEngine.Common.Services.CurrentUserService>();

            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<ValidationExceptionHandlingMiddleware>();
            services.AddScoped<CancellationTokenCaptureMiddleware>();
            services.AddScoped<CancellationTokenAccessor>();

            // Register the standard IdGen Snowflake ID Generator (originally developed by Twitter)
            // Generator ID 0 is used as the machine/worker ID.
            services.AddSingleton<IdGen.IIdGenerator<long>>(x => new IdGen.IdGenerator(0));


            return services;
        }
    }
}
