using OnlineCinema.Api.Controllers.Genre.Models.Mappers;
using OnlineCinema.Api.Controllers.Movie.Models;
using OnlineCinema.Api.Controllers.Payment.Models.Mappers;
using OnlineCinema.Api.Controllers.Subscription.Models.Mappers;
using OnlineCinema.BL.Mapper;

namespace OnlineCinema.Api.Configuration;

public static class MapperConfigurator
{
    public static void ConfigureMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<GenreBLProfile>();
            config.AddProfile<MovieBLProfile>();
            config.AddProfile<PaymentBLProfile>();
            config.AddProfile<SubscriptionBLProfile>();

            config.AddProfile<CreateMovieRequestProfile>();
            config.AddProfile<CreateGenreRequestProfile>();
            config.AddProfile<CreateSubscriptionRequestProfile>();
            config.AddProfile<CreatePaymentRequestProfile>();
        });
    }
}
