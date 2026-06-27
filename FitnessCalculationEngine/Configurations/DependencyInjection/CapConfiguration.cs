using FitnessCalculationEngine.Data.Contexts;

namespace ProductCatalogAPI.Configurations.DependencyInjection
{
    public static class CapConfiguration
    {
        public static IServiceCollection AddCapConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCap(x =>
            {
                // Register Entity Framework Core to be used for storing CAP messages (outbox pattern)
                x.UseEntityFramework<Context>();

                // Configure SQL Server (matching your existing DB setup)
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                // Configure RabbitMQ as the message broker
                x.UseRabbitMQ(options =>
                {
                    options.HostName = configuration["RabbitMQ:HostName"] ?? "localhost";
                    options.UserName = configuration["RabbitMQ:UserName"] ?? "guest";
                    options.Password = configuration["RabbitMQ:Password"] ?? "guest";
                    // Default port is 5672
                });

                // Dashboard is available via the DotNetCore.CAP.Dashboard package if needed
                // x.UseDashboard();
            });

            return services;
        }
    }
}
