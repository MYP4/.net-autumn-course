using OnlineCinema.BL.Subscription.Entities;

namespace OnlineCinema.Api.Controllers.Subscription.Models;

public class SubscriptionListResponce
{
    public List<SubscriptionModel> Subscriptions { get; set; }
}
