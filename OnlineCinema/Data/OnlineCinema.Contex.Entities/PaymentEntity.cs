using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Contex.Entities;

[Table("payments")]
public class PaymentEntity : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }


    public int UserId { get; set; }
    public UserEntity User { get; set; }


    public int SubscriptionId { get; set; }
    public SubscriptionEntity Subscription { get; set; }
}
