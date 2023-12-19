using AutoMapper;
using OnlineCinema.Api.Controllers.Genre.Models;
using OnlineCinema.BL.Entities.Genres.Entities;

namespace OnlineCinema.Api.Controllers.Genre.Models.Mappers;

public class CreateGenreRequestProfile : Profile
{
    public CreateGenreRequestProfile()
    {
        CreateMap<CreateGenreRequest, CreateGenreModel>();
    }
}
