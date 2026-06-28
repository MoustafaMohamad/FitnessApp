using Workout_Exercise_Catalog.Common.Behaviors;

namespace Workout_Exercise_Catalog.Configurations.DependencyInjection
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfigration(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });
            return services;
        }
    }
}
