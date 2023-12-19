using AutoMapper;
using OnlineCinema.Api.Controllers.Movie.Entities;
using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.Api.Controllers.Movie.Models;

public class CreateMovieRequestProfile : Profile
{
    public CreateMovieRequestProfile()
    {
        CreateMap<CreateMovieRequest, CreateMovieModel>();
        CreateMap<MoviesFilter, MovieModelFilter>();
        CreateMap<UpdateMovieRequest, UpdateMovieModel>();
    }
}
