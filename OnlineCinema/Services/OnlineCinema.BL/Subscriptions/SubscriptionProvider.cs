using AutoMapper;
using OnlineCinema.BL.Subscription.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Subscription;

public class SubscriptionProvider : ISubscriptionProvider
{
    private readonly IRepository<SubscriptionEntity> _subscriptionRepository;
    private readonly IMapper _mapper;

    public SubscriptionProvider(IRepository<SubscriptionEntity> subscriptionRepository, IMapper mapper)
    {
        _subscriptionRepository = subscriptionRepository;
        _mapper = mapper;
    }

    public SubscriptionModel GetSubscriptionInfo(Guid id)
    {
        var movie = _subscriptionRepository.GetByGuid(id);

        if (movie is null)
        {
            throw new ArgumentException("Movie not found");
        }

        return _mapper.Map<SubscriptionModel>(movie);
    }

    public IEnumerable<SubscriptionModel> GetSubscriptions(SubscriptionModelFilter filter = null)
    {
        var name = filter?.Name;
        var price = filter?.Price;


        var movies = _subscriptionRepository
            .GetAll(x => (name == null || x.Name == name) &&
                         (price == null || x.Price == price));


        return _mapper.Map<IEnumerable<SubscriptionModel>>(movies);
    }
}
