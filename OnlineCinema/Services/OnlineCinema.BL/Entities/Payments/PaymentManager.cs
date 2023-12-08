using AutoMapper;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Payments.Entity;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Payments;

public class PaymentManager : IPaymentManager
{
    private readonly IRepository<PaymentEntity> _PaymentRepository;
    private readonly IMapper _mapper;

    public PaymentManager(IRepository<PaymentEntity> PaymentRepository, IMapper mapper)
    {
        _PaymentRepository = PaymentRepository;
        _mapper = mapper;
    }

    public PaymentModel CreatePayment(CreatePaymentModel model)
    {
        var entity = _mapper.Map<PaymentEntity>(model);

        _PaymentRepository.Save(entity);

        return _mapper.Map<PaymentModel>(entity);
    }

    public void DeletePayment(Guid id)
    {
        var entity = _PaymentRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("Payment not found");
        }

        _PaymentRepository.Delete(entity);
    }
}
