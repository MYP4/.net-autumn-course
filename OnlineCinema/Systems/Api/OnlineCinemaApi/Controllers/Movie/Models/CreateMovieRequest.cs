using OnlineCinema.Context.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.Api.Controllers.Movie.Models;

public class CreateMovieRequest : IValidatableObject
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Link { get; set; } // link to the movie

    [Range(0, 5)]
    public double Rating { get; set; }

    [Required]
    public int Duration { get; set; } // in minutes

    [Required]
    [Range(0, 5)]
    public AgeLimitEnum AgeLimit { get; set; }

    [Required]
    public int GenreId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return new ValidationResult[] { };
    }
}
