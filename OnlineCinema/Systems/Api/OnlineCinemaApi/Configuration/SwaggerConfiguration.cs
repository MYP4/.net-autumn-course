using OnlineCinema.BL.Movies;

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

        services.AddSingleton<IMovieProvider, MovieProvider>();
        services.AddSingleton<IMovieManager, MovieManager>();
    }


    public static void ConfigureApplication(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

}
