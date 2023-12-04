using AutoMapper;
using OnlineCinema.BL.Helpers;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Movies;

public class MovieProvider : IMovieProvider
{
    private readonly IRepository<MovieEntity> _movieRepository;
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public MovieProvider(IRepository<MovieEntity> movieRepository, IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _userRepository = userRepository;
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

    public IEnumerable<MovieModel> GetMovies(Guid userId, MoviesModelFilter filter = null)
    {
        var ageLimit = filter?.AgeLimit;
        var rating = filter?.Rating;
        var genre = filter?.Genre;

        var currentDate = DateTime.UtcNow;
        var currentUser = _userRepository.GetByGuid(userId);

        var movies = _movieRepository
            .GetAll(x => (ageLimit == null || AgeHelper.GetAge(currentUser.Birthday) >= ageLimit) &&
                         (rating == null || x.Rating == rating) &&
                         (genre == null || x.Genre.Equals(genre)));


        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}
