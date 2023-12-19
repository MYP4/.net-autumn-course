using AutoMapper;
using OnlineCinema.BL.Movies.Entities;

namespace OnlineCinema.Api.Controllers.Movie.Models;

public class CreateMovieRequestProfile : Profile
{
    public CreateMovieRequestProfile()
    {
        CreateMap<CreateMovieRequest, CreateMovieModel>();
    }
}
