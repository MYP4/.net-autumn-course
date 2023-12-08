using OnlineCinema.BL.Entities.Genres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Entities.Genres;

public interface IGenreManager
{
    GenreModel CreateGenre(CreateGenreModel model);
    GenreModel UpdateGenre(Guid id, UpdateGenreModel model);
    void DeleteGenre(Guid id);
}
