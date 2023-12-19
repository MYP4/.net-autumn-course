using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Movies.Entities;

public class UpdateMovieModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
}
