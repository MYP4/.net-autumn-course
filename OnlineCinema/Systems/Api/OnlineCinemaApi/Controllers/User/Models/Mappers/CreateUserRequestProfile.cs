using AutoMapper;
using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.Api.Controllers.User.Models.Mappers;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserModel>();
        CreateMap<UsersFilter, UserModelFilter>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}
