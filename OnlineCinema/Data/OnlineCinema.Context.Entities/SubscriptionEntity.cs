using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("subscriptions")]
public class SubscriptionEntity : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ICollection<PaymentEntity> Payments { get; set; }


    public ICollection<MovieEntity> Movies { get; set; }
}
