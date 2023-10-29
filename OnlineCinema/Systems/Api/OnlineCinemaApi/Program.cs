using OnlineCinema.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.AddAppLogger();

// ----------------------------

var services = builder.Services;

services.AddAppHealthChecks();
services.AddHttpContextAccessor();
services.AddAppCors();

services.ConfigureServices();

services.AddControllers();


// ----------------------------

var app = builder.Build();

app.ConfigureApplication();
app.UseAppHealthChecks();
app.UseAuthorization();
app.MapControllers();

app.Run();
