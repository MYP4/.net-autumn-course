using AutoMapper;
using OnlineCinema.Api.Controllers.Movie.Entities;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Subscription.Entities;

namespace OnlineCinema.Api.Controllers.Subscription.Models.Mappers;

public class CreateSubscriptionRequestProfile: Profile
{
    public CreateSubscriptionRequestProfile()
    {
        CreateMap<CreateSubscriptionRequest, CreateSubscriptionModel>();
        CreateMap<SubscriptionsFilter, SubscriptionModelFilter>();
        CreateMap<UpdateSubscriptionRequest, UpdateSubscriptionModel>();
    }
}
