using OnlineCinema.BL.Entities.Genres.Entities;

namespace OnlineCinema.BL.Entities.Genres;

public interface IGenreProvider
{
    IEnumerable<GenreModel> GetGenres(GenreModelFilter filter = null);
    GenreModel GetGenreInfo(Guid id);
}
