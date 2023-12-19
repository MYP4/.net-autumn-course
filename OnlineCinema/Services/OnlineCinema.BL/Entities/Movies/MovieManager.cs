using AutoMapper;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Movies;

public class MovieManager : IMovieManager
{
    private readonly IRepository<MovieEntity> _moviesRepository;
    private readonly IMapper _mapper;

    public MovieManager(IRepository<MovieEntity> moviesRepository, IMapper mapper)
    {
        _moviesRepository = moviesRepository;
        _mapper = mapper;
    }

    public MovieModel CreateMovie(CreateMovieModel model)
    {
        var entity = _mapper.Map<MovieEntity>(model);

        _moviesRepository.Save(entity);

        return _mapper.Map<MovieModel>(entity);
    }


    public MovieModel UpdateMovie(Guid id, UpdateMovieModel model)
    {
        var entity = _moviesRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("Movie not found");
        }

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Director = model.Director;


        _moviesRepository.Save(entity);

        return _mapper.Map<MovieModel>(entity);
    }


    public void DeleteMovie(Guid movieId)
    {
        var entity = _moviesRepository.GetByGuid(movieId);

        if (entity == null)
        {
            throw new ArgumentException("Movie not found");
        }

        _moviesRepository.Delete(entity);
    }
}
