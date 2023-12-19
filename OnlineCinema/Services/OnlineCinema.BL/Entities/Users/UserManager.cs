using AutoMapper;
using OnlineCinema.BL.Users.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Users;

public class UserManager : IUserManager
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;

    public UserManager(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);

        _usersRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }


    public UserModel UpdateUser(Guid id, UpdateUserModel model)
    {
        var entity = _usersRepository.GetByGuid(id);

        if (entity == null)
        {
            throw new ArgumentException("User not found");
        }

        entity.FirstName = model.FirstName;
        entity.SecondName = model.SecondName;


        _usersRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }


    public void DeleteUser(Guid movieId)
    {
        var entity = _usersRepository.GetByGuid(movieId);

        if (entity == null)
        {
            throw new ArgumentException("User not found");
        }

        _usersRepository.Delete(entity);
    }
}
