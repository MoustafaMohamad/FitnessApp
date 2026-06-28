using System.Reflection;
using System.Text.Json.Serialization;
using Workout_Exercise_Catalog.Common.Middlewares;
using Workout_Exercise_Catalog.Common.Profiles;
using Workout_Exercise_Catalog.Configurations.DependencyInjection;
using Workout_Exercise_Catalog.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services
                .AddFluentValidation(Assembly.GetExecutingAssembly())
                .AddMediatRConfigration()
                .AddMapsterConfig(typeof(Profile))
                .AddDBContext(builder.Configuration)
                .AddApplicationServices()
                //.AddAuthenticationConfiguration(builder.Configuration)
                //.AddAuthorizationConfiguration()
                .AddSwaggerConfiguration();
builder.Services.AddCap(x =>
{
    x.UseEntityFramework<Context>();

    x.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));

    x.UseRabbitMQ(options =>
    {
        options.HostName = "localhost";
        options.Port = 5672;
        options.UserName = "guest";
        options.Password = "guest";
    });
}); var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<TransactionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UserStateMiddleware>();
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
app.UseMiddleware<CancellationTokenCaptureMiddleware>();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
