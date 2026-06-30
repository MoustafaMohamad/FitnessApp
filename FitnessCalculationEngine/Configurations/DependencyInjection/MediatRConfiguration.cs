using FitnessCalculationEngine;
using FitnessCalculationEngine.Common.Behaviors;

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfigration(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionMiddleware<,>));
            });
            return services;
        }
    }
}
