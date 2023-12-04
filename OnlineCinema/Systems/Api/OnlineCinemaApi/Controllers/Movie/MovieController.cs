using AutoMapper;
using OnlineCinema.BL;
using OnlineCinema.Api.Controllers.Movie.Entities;

using Microsoft.AspNetCore.Mvc;
using OnlineCinema.BL.Movies;

namespace OnlineCinema.Api.Controllers.Movie;


[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private readonly IMovieProvider _movieProvider;
    private readonly IMovieManager _movieManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public MovieController(IMovieProvider movieProvider, IMovieManager movieManager, IMapper mapper, ILogger logger)
    {
        _movieManager = movieManager;
        _movieProvider = movieProvider;
        _mapper = mapper;
        _logger = logger;
    }


    [HttpGet]
    public IActionResult GetAllMovies()
    {
        //var movies = _movieProvider.GetMovies();

        return Ok();
    }


    [HttpGet]
    [Route("{id}")]
    public IActionResult GetMovieInfo(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredMovies([FromQuery] MoviesFilter filter)
    {
        return Ok();
    }


    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieRequest request)
    {
        try
        {

            return Ok();
        }
        catch (ArgumentException ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateMovieInfo([FromRoute] Guid id, UpdateMovieRequest request)
    {

        return Ok();
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteMovie([FromRoute] Guid id)
    {
        return Ok();
    }
}
