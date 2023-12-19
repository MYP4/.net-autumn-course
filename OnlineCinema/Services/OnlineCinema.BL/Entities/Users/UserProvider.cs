using AutoMapper;
using OnlineCinema.BL.Users.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Users;

public class UserProvider : IUserProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UserProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserModel GetUserInfo(Guid id)
    {
        var User = _userRepository.GetByGuid(id);

        if (User is null)
        {
            throw new ArgumentException("User not found");
        }

        return _mapper.Map<UserModel>(User);
    }


    public IEnumerable<UserModel> GetUsers(UserModelFilter filter = null)
    {
        var firstName = filter?.FirstName;
        var secondName = filter?.SecondName;

        var currentDate = DateTime.UtcNow;

        var Users = _userRepository
            .GetAll(x => (firstName == null || x.FirstName.Equals(firstName)) &&
                         (secondName == null || x.SecondName.Equals(secondName)));


        return _mapper.Map<IEnumerable<UserModel>>(Users);
    }
}
