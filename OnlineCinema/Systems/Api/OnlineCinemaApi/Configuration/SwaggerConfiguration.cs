namespace OnlineCinema.Api.Configuration;


/// <summary>
/// Static class for Swagger configuration
/// </summary>
public static class SwaggerConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }


    public static void ConfigureApplication(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

}
