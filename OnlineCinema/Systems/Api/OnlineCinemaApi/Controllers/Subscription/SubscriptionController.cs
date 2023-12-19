using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Api.Controllers.Movie;
using OnlineCinema.Api.Controllers.Subscription.Models;
using OnlineCinema.BL.Movies;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.BL.Subscription;
using OnlineCinema.BL.Subscription.Entities;

namespace OnlineCinema.Api.Controllers.Subscription;


[ApiController]
[Route("[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionProvider _subscriptionsProvider;
    private readonly ISubscriptionManager _subscriptionsManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public SubscriptionController(ISubscriptionProvider subscriptionsProvider, ISubscriptionManager subscriptionsManager, IMapper mapper, ILogger<MovieController> logger)
    {
        _subscriptionsManager = subscriptionsManager;
        _subscriptionsProvider = subscriptionsProvider;
        _mapper = mapper;
        _logger = logger;
    }



    [HttpGet]
    public IActionResult GetAllSubscriptions()
    {
        var subscriptions = _subscriptionsProvider.GetSubscriptions();
        return Ok(new SubscriptionListResponce()
        {
            Subscriptions = subscriptions.ToList()
        });
    }


    [HttpGet]
    [Route("{id}")]
    public IActionResult GetSubscriptionInfo(Guid id)
    {
        try
        {
            var subscription = _subscriptionsProvider.GetSubscriptionInfo(id);
            return Ok(subscription);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString()); //stack trace + message
            return NotFound(ex.Message);
        }
    }


    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredSubscriptions([FromQuery] SubscriptionsFilter filter)
    {
        var subscriptions = _subscriptionsProvider.GetSubscriptions(_mapper.Map<SubscriptionModelFilter>(filter));
        return Ok(new SubscriptionListResponce()
        {
            Subscriptions = subscriptions.ToList()
        });
    }


    [HttpPost]
    public IActionResult CreateSubscription([FromBody] CreateSubscriptionRequest request)
    {
        try
        {
            var subscription = _subscriptionsManager.CreateSubscription(_mapper.Map<CreateSubscriptionModel>(request));
            return Ok(subscription);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateSubscriptionInfo([FromRoute] Guid id, UpdateSubscriptionRequest request)
    {
        try
        {
            _subscriptionsManager.UpdateSubscription(id, _mapper.Map<UpdateSubscriptionModel>(request));
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteSubscription([FromRoute] Guid id)
    {
        try
        {
            _subscriptionsManager.DeleteSubscription(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }
}
