using OnlineCinema.Api.Controllers.Movie.Models;
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
        });
    }
}
