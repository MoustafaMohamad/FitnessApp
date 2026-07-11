using ProductCatalogAPI.Configurations.DependencyInjection;
using ProgressTrackingService.Configurations.DependencyInjection;
using ProgressTrackingService.Features.Progress.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDBContext(builder.Configuration);
builder.Services.AddCapConfiguration(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddMapsterConfiguration();
builder.Services.AddMediatRConfigration();
builder.Services.AddFluentValidation(typeof(Program).Assembly);
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
//app.MapGet("/", () => Results.Redirect("/swagger"));
//app.MapWorkoutLogEndpoints();
app.MapProgressEndpoints();



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
