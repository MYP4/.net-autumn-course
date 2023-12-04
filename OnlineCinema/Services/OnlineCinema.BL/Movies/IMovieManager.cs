using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.BL.Movies;

public interface IMovieManager
{
    MovieModel CreateMovie(CreateMovieModel model);
    void UpdateMovie(Guid id, UpdateMovieModel movie);
    void DeleteMovie(Guid id);
}
