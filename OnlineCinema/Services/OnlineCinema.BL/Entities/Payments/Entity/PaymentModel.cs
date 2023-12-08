using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Payments.Entity;

public class PaymentModel
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public UserEntity User { get; set; }
    public SubscriptionEntity Subscription { get; set; }
}
