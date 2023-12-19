using OnlineCinema.BL.Movies;
using OnlineCinema.BL.Payments;
using OnlineCinema.BL.Subscription;
using Repository;

namespace OnlineCinema.Api.Configuration;

public static class ServicesConfigurator
{
    public static void ConfigureService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IMovieManager, MovieManager>();
        services.AddScoped<IMovieProvider, MovieProvider>();
        services.AddScoped<IPaymentManager, PaymentManager>();
        services.AddScoped<IPaymentProvider, PaymentProvider>();
        services.AddScoped<ISubscriptionManager, SubscriptionManager>();
        services.AddScoped<ISubscriptionProvider, SubscriptionProvider>();

        //services.AddScoped<IUserProvider, UserProvider>();
        //services.AddScoped<IUserProvider, UserProvider>();
    }
}
