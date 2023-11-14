using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCinema.Context;
using System.Configuration;

namespace OnlineCinema.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    protected readonly string ConnectionString;
    protected readonly IDbContextFactory<OnlineCinemaDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;

    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        ConnectionString = configuration.GetConnectionString("OnlineCinemaDbContext") ?? "";
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<OnlineCinemaDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<OnlineCinemaDbContext>(
            options => { options.UseSqlServer(ConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }
}
