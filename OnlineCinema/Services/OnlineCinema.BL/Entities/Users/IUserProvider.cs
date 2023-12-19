using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.BL.Users;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(UserModelFilter filter = null);
    UserModel GetUserInfo(Guid id);
}
