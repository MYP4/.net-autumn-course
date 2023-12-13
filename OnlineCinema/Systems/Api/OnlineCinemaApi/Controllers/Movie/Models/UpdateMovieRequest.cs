namespace OnlineCinema.Api.Controllers.Movie.Entities;

public class UpdateMovieRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; } 
    public double Rating { get; set; }
}
