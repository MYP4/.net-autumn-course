using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.BL.Movies;

public interface IMovieProvider
{
    IEnumerable<MovieModel> GetMovies(MovieModelFilter filter = null);
    MovieModel GetMovieInfo(Guid id);
}
