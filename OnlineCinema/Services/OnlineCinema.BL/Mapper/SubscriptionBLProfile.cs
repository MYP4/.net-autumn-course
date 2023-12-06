using AutoMapper;
using OnlineCinema.BL.Subscription.Entities;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Mapper;

public class SubscriptionBLProfile : Profile
{
    public SubscriptionBLProfile()
    {
        CreateMap<SubscriptionEntity, SubscriptionModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));


        CreateMap<CreateSubscriptionModel, SubscriptionEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
