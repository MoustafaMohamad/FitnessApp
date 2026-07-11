using ProgressTrackingService.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProgressTrackingService.Configurations.DependencyInjection
{
    public static class ContextConfigration
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
