using AutoMapper;
using OnlineCinema.BL.Payments.Entity;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Mapper;

public class PaymentBLProfile : Profile
{
    public PaymentBLProfile()
    {
        CreateMap<PaymentEntity, PaymentModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));


        CreateMap<CreatePaymentModel, PaymentEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
