using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineCinema.BL.Entities.Auth;
using OnlineCinema.BL.Movies;
using OnlineCinema.BL.Payments;
using OnlineCinema.BL.Subscription;
using OnlineCinema.BL.Users;
using OnlineCinema.Context.Entities;
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


        services.AddScoped<IAuthProvider>(x => new AuthProvider(
                                            x.GetRequiredService<SignInManager<UserEntity>>(),
                                            x.GetRequiredService<UserManager<UserEntity>>(),
                                            x.GetRequiredService<IHttpClientFactory>(),
                                            "http://localhost:5151",
                                            "IdentityServerSettings:ClientId",
                                            "IdentityServerSettings"));

        services.AddScoped<IUserProvider>(x => new UserProvider(
                                            x.GetRequiredService<UserManager<UserEntity>>(),
                                            x.GetRequiredService<IMapper>()));

        services.AddScoped<IUserManager>(x => new UserManager(
                                            x.GetRequiredService<UserManager<UserEntity>>(),
                                            x.GetRequiredService<IMapper>()));
    }
}
