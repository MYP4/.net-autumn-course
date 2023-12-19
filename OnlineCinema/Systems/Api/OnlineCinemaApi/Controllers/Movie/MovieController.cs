using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Api.Controllers.Movie.Entities;
using OnlineCinema.Api.Controllers.Movie.Models;
using OnlineCinema.BL.Movies;
using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.Api.Controllers.Movie;


[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieProvider _moviesProvider;
    private readonly IMovieManager _moviesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public MovieController(IMovieProvider moviesProvider, IMovieManager moviesManager, IMapper mapper, ILogger<MovieController> logger)
    {
        _moviesManager = moviesManager;
        _moviesProvider = moviesProvider;
        _mapper = mapper;
        _logger = logger;
    }


    [HttpGet]
    public IActionResult GetAllMovies(Guid userId)
    {
        var movies = _moviesProvider.GetMovies(userId);
        return Ok(new MoviesListResponce()
        {
            Movies = movies.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetMovieInfo([FromRoute] Guid id)
    {
        try
        {
            var movie = _moviesProvider.GetMovieInfo(id);
            return Ok(movie);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString()); //stack trace + message
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("user_filter")]
    public IActionResult GetFilteredMovies(Guid userId, [FromQuery] MoviesFilter filter)
    {
        var movies = _moviesProvider.GetMovies(userId, _mapper.Map<MovieModelFilter>(filter));
        return Ok(new MoviesListResponce()
        {
            Movies = movies.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredMovies([FromQuery] MoviesFilter filter)
    {
        var movies = _moviesProvider.GetMovies(_mapper.Map<MovieModelFilter>(filter));
        return Ok(new MoviesListResponce()
        {
            Movies = movies.ToList()
        });
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieRequest request)
    {
        try
        {
            var movie = _moviesManager.CreateMovie(_mapper.Map<CreateMovieModel>(request));
            return Ok(movie);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateMovieInfo([FromRoute] Guid id, UpdateMovieRequest request)
    {
        try
        {
            _moviesManager.UpdateMovie(id, _mapper.Map<UpdateMovieModel>(request));
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteMovie([FromRoute] Guid id)
    {
        try
        {
            _moviesManager.DeleteMovie(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }
}
