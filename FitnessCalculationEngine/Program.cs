using MapsterMapper;
using FitnessCalculationEngine.Common.Middlewares;
using ProductCatalogAPI.Configurations.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;
using FitnessCalculationEngine.Configurations.DependencyInjection;
namespace FitnessCalculationEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();


            builder.Services
                .AddFluentValidation(Assembly.GetExecutingAssembly())
                .AddMediatRConfigration()
                .AddMapsterConfiguration()
                .AddDBContext(builder.Configuration)
                .AddApplicationServices()
                .AddAuthenticationConfiguration(builder.Configuration)
                .AddCapConfiguration(builder.Configuration)
                .AddSwaggerConfiguration()
                .AddJwtConfiguration(builder.Configuration);


            builder.Logging.ClearProviders();

            #region Serilog Configuration 

               Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
               .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"), restrictedToMinimumLevel: LogEventLevel.Information,
               sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true, AutoCreateSqlDatabase = true })
               .WriteTo.Seq("http://localhost:5341/")
               .CreateLogger();

            builder.Host.UseSerilog();
            #endregion


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
            app.UseMiddleware<CancellationTokenCaptureMiddleware>();

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}