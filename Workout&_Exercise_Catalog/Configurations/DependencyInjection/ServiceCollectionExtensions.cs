using Workout_Exercise_Catalog.Common;
using Workout_Exercise_Catalog.Common.Helpers;
using Workout_Exercise_Catalog.Common.Middlewares;
using Workout_Exercise_Catalog.Common.Repositories;
using Workout_Exercise_Catalog.Data.Contexts;
using Workout_Exercise_Catalog.Features.Common;

namespace Workout_Exercise_Catalog.Configurations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();


            //services.AddScoped<IPasswordHasher, PasswordHasher>();
            //services.AddScoped<ITokenHelper, TokenHelper>();



            services.AddScoped<CancellationTokenAccessor>();
            services.AddScoped<RequestParameters>();
            services.AddScoped<NotificationParameters>();
            services.AddScoped<UserState>();


            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<UserStateMiddleware>();
            services.AddScoped<ValidationExceptionHandlingMiddleware>();
            services.AddScoped<CancellationTokenCaptureMiddleware>();





            // Services
            //services.AddScoped<IJwtService, JwtService>();


            // HttpContext

            return services;
        }
    }
}
