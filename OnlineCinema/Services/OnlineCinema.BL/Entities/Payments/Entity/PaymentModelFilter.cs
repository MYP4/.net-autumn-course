namespace OnlineCinema.BL.Payments.Entity;

public class PaymentModelFilter
{
    public Guid? UserId { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}
