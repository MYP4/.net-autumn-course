using AutoMapper;
using OnlineCinema.BL.Entities.Genres.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Entities.Genres;

public class GenreProvider : IGenreProvider
{
    private readonly IRepository<GenreEntity> _genreRepository;
    private readonly IMapper _mapper;

    public GenreProvider(IRepository<GenreEntity> genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public GenreModel GetGenreInfo(Guid id)
    {
        var genre = _genreRepository.GetByGuid(id);

        if (genre is null)
        {
            throw new NotImplementedException();
        }

        return _mapper.Map<GenreModel>(genre);
    }

    public IEnumerable<GenreModel> GetGenres(GenreModelFilter filter = null)
    {
        var name = filter?.Name;
        var description = filter?.Description;

        var genres = _genreRepository
            .GetAll(x => (name == null || x.Name.Equals(name)) &&
                         (description == null || x.Description.Equals(description)));

        return _mapper.Map<IEnumerable<GenreModel>>(genres);
    }
}
