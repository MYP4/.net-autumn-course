using AutoMapper;
using OnlineCinema.BL.Payments.Entity;
using OnlineCinema.BL.Users.Entities;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Mapper;

public class UserBLProfile : Profile
{
    public UserBLProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));
    }
}
