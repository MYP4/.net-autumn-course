using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Payments.Entity;

namespace OnlineCinema.BL.Payments;

public interface IPaymentProvider
{
    IEnumerable<PaymentModel> GetMovies(PaymentModelFilter filter = null);
    PaymentModel GetMovieInfo(Guid id);
}
