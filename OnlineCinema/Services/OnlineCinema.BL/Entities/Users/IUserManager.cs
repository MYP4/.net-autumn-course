using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.BL.Users;

public interface IUserManager
{
    Task<UserModel> CreateUser(CreateUserModel model);
    Task UpdateUser(Guid id, UpdateUserModel model);
    Task DeleteUser(Guid id);
}
