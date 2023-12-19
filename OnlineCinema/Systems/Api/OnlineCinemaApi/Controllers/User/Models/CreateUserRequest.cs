using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Api.Controllers.User.Models;

public class CreateUserRequest : IValidatableObject
{
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    public string SecondName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        if (Birthday < new DateTime(1900, 1, 1))
        {
            errors.Add(new ValidationResult("Birthday must be greater than 1900 year."));
        }

        return errors;
    }
}
