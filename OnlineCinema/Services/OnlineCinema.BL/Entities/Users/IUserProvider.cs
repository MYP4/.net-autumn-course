using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.BL.Users;

public interface IUserProvider
{
    Task<IEnumerable<UserModel>> GetUsers(UserModelFilter filter = null);
    Task<UserModel> GetUserInfo(Guid id);
}
