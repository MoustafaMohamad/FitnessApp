using FluentValidation;
using System.Reflection;

namespace ProgressTrackingService.Configurations.DependencyInjection
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
