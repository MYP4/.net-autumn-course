using AutoMapper;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Movies;

public class MovieProvider : IMovieProvider
{
    private readonly IRepository<MovieEntity> _movieRepository;
    private readonly IMapper _mapper;

    public MovieProvider(IRepository<MovieEntity> movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public MovieModel GetMovieInfo(Guid id)
    {
        var movie = _movieRepository.GetByGuid(id);

        if (movie is null)
        {
            throw new ArgumentException("Movie not found");
        }

        return _mapper.Map<MovieModel>(movie);
    }


    public IEnumerable<MovieModel> GetMovies(MovieModelFilter filter = null)
    {
        var rating = filter?.Rating;
        var genre = filter?.Genre;

        var currentDate = DateTime.UtcNow;

        var movies = _movieRepository
            .GetAll(x => (rating == null || x.Rating == rating) &&
                         (genre == null || x.Genre.Equals(genre)));


        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}
