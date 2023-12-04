using AutoMapper;
using OnlineCinema.BL.Subscription.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Subscription;

public class SubscriptionManager : ISubscriptionManager
{
    private readonly IRepository<SubscriptionEntity> _subscriptionRepository;
    private readonly IMapper _mapper;

    public SubscriptionManager(IRepository<SubscriptionEntity> subscriptionRepository, IMapper mapper)
    {
        _subscriptionRepository = subscriptionRepository;
        _mapper = mapper;
    }

    public SubscriptionModel CreateSubscription(CreateSubscriptionModel model)
    {
        var entity = _mapper.Map<SubscriptionEntity>(model);

        _subscriptionRepository.Save(entity);

        return _mapper.Map<SubscriptionModel>(entity);
    }


    public SubscriptionModel UpdateSubscription(Guid id, UpdateSubscriptionModel model)
    {
        var entity = _subscriptionRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("Subscription not found");
        }

        entity.Name = model.Name;
        entity.Price = model.Price;

        _subscriptionRepository.Save(entity);

        return _mapper.Map<SubscriptionModel>(entity);
    }


    public void DeleteSubscription(Guid id)
    {
        var entity = _subscriptionRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("Subscription not found");
        }

        _subscriptionRepository.Delete(entity);
    }
}
