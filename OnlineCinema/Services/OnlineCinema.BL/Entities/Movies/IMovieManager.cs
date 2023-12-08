using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.BL.Movies;

public interface IMovieManager
{
    MovieModel CreateMovie(CreateMovieModel model);
    MovieModel UpdateMovie(Guid id, UpdateMovieModel model);
    void DeleteMovie(Guid id);
}
