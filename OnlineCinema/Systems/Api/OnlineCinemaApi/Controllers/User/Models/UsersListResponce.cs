using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.Api.Controllers.User.Models;

public class UsersListResponce
{
    public List<UserModel> Users { get; set; }
}
