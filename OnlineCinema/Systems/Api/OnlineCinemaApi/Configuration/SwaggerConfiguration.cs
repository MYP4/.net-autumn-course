using OnlineCinema.BL.Movies;

namespace OnlineCinema.Api.Configuration;


public static class SwaggerConfiguration
{
    public static void ConfigureSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }


    public static void ConfigureSwaggerApplication(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

}
