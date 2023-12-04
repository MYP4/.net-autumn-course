namespace OnlineCinema.Api.Controllers.Movie.Entities;

public class MoviesFilter
{
    public string? Genre { get; set; }
    public double? Rating { get; set; }
    public int? AgeLimit { get; set; }
}
