using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Movies.Entities;

public class UpdateMovieModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Link { get; set; }         // link to the movie
    public double Rating { get; set; }
    public int Duration { get; set; }       // in minutes
    public AgeLimitEnum AgeLimit { get; set; }
    public GenreEntity Genre { get; set; }
}
