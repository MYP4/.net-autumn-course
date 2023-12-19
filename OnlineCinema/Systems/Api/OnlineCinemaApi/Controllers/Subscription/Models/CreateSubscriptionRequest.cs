using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Api.Controllers.Subscription.Models;

public class CreateSubscriptionRequest : IValidatableObject
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        if (Price < 100)
        {
            errors.Add(new ValidationResult("The price should be higher"));
        }
        return errors;
    }
}
