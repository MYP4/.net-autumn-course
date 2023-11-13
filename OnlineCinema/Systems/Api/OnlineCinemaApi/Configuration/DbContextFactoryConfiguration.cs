using Microsoft.EntityFrameworkCore;
using OnlineCinema.Context;

namespace OnlineCinema.Api.Configuration;

public static class DbContextFactoryConfiguration
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<OnlineCinemaDbContext>(
            options => { options.UseSqlServer(connectionString); },
            ServiceLifetime.Scoped);

        return services;
    }

    public static IApplicationBuilder UseDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<OnlineCinemaDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist

        return app;
    }
}