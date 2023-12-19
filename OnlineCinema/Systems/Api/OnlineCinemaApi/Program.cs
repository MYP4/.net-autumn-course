using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineCinema.Api.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

// ----------------------------

var services = builder.Services;


// Configure DB
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = configuration.GetConnectionString("OnlineCinemaDbContext");

services.AddDataBase(connectionString ?? "");



services.AddHttpContextAccessor();

services.ConfigureSwaggerServices();
services.ConfigureMapperServices();
services.ConfigureService();

services.AddControllers();


// ----------------------------

var app = builder.Build();

app.ConfigureSwaggerApplication();
app.UseAuthorization();
app.MapControllers();

app.UseDataBase();


app.Run();
