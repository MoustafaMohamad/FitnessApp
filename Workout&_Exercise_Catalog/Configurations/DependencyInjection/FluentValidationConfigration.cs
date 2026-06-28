using FluentValidation;
using System.Reflection;

namespace Workout_Exercise_Catalog.Configurations.DependencyInjection
{
    public static class FluentValidationConfigration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
