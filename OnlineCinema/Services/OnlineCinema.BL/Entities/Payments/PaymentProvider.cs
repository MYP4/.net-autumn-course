using OnlineCinema.BL.Payments.Entity;

namespace OnlineCinema.BL.Payments;

public class PaymentProvider : IPaymentProvider
{
    public PaymentModel GetMovieInfo(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PaymentModel> GetMovies(PaymentModelFilter filter = null)
    {
        throw new NotImplementedException();
    }
}
