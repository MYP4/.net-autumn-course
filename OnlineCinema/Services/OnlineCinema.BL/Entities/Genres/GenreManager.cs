using AutoMapper;
using OnlineCinema.BL.Entities.Genres.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Entities.Genres;

public class GenreManager : IGenreManager
{
    private readonly IRepository<GenreEntity> _genreRepository;
    private readonly IMapper _mapper;

    public GenreManager(IRepository<GenreEntity> genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }


    public GenreModel CreateGenre(CreateGenreModel model)
    {
        var entity = _mapper.Map<GenreEntity>(model);

        _genreRepository.Save(entity);

        return _mapper.Map<GenreModel>(entity);
    }

    public void DeleteGenre(Guid id)
    {
        var entity = _genreRepository.GetByGuid(id);

        if (entity == null) 
        { 
            throw new ArgumentException("Genre not found"); 
        }

        _genreRepository.Delete(entity);
    }

    public GenreModel UpdateGenre(Guid id, UpdateGenreModel model)
    {
        var entity = _genreRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("Genre not found");
        }

        entity.Name = model.Name;
        entity.Description = model.Description;

        _genreRepository.Save(entity);

        return _mapper.Map<GenreModel>(entity);
    }
}
