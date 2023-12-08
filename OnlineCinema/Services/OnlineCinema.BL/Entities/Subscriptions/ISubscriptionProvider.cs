using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Subscription.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Subscription;

public interface ISubscriptionProvider
{
    IEnumerable<SubscriptionModel> GetSubscriptions(SubscriptionModelFilter filter = null);
    SubscriptionModel GetSubscriptionInfo(Guid id);
}
