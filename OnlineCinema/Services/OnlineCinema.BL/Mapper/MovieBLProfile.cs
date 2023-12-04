using AutoMapper;
using OnlineCinema.BL.Movies.Entities;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Mapper;

public class MovieBLProfile : Profile
{
    public MovieBLProfile()
    {
        CreateMap<MovieEntity, MovieModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));


        CreateMap<CreateMovieModel, MovieEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
