using OnlineCinema.BL.Subscription.Entities;

namespace OnlineCinema.BL.Subscription;

public interface ISubscriptionManager
{
    SubscriptionModel CreateSubscription(CreateSubscriptionModel model);
    SubscriptionModel UpdateSubscription(Guid id, UpdateSubscriptionModel model);
    void DeleteSubscription(Guid id);
}
