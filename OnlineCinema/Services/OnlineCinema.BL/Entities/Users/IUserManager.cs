using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.BL.Users;

public interface IUserManager
{
    UserModel CreateUser(CreateUserModel model);
    UserModel UpdateUser(Guid id, UpdateUserModel model);
    void DeleteUser(Guid id);
}
