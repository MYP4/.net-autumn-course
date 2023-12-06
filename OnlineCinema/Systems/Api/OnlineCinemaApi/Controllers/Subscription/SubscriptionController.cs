using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Api.Controllers.Subscription.Models;

namespace OnlineCinema.Api.Controllers.Subscription;

public class SubscriptionController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAllSubscriptions()
    {
        return Ok();
    }


    [HttpGet]
    [Route("{id}")]
    public IActionResult GeSubscriptionInfo(Guid id)
    {
        return Ok();
    }


    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredSubscriptions([FromQuery] SubscriptionsFilter filter)
    {
        return Ok();
    }


    //[HttpPost]
    //public IActionResult CreateSubscription([FromBody] CreateSubscriptionRequest request)
    //{
    //    try
    //    {

    //    }
    //    catch (ArgumentException ex)
    //    {

    //    }
    //}

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateSubscriptionInfo([FromRoute] Guid id, UpdateSubscriptionRequest request)
    {

        return Ok();
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteSubscription([FromRoute] Guid id)
    {
        return Ok();
    }
}
