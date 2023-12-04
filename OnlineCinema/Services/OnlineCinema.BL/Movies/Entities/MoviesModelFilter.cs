using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Movies.Entities;

public class MoviesModelFilter
{
    public string? Genre { get; set; }
    public double? Rating { get; set; }
    public int? AgeLimit { get; set; }
}

