using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Payments.Entity;

namespace OnlineCinema.BL.Payments;

public interface IPaymentManager
{
    PaymentModel CreatePayment(CreatePaymentModel model);
    void DeletePayment(Guid id);
}
