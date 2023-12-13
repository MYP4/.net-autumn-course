using AutoMapper;
using OnlineCinema.BL.Entities.Genres.Entities;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Mapper;

public class GenreBLProfile : Profile
{
    public GenreBLProfile()
    {
        CreateMap<GenreEntity, GenreModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));


        CreateMap<CreateGenreModel, GenreEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}
