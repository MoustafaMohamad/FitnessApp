using Microsoft.EntityFrameworkCore;
using Workout_Exercise_Catalog.Data.Contexts;

namespace Workout_Exercise_Catalog.Configurations.DependencyInjection
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
