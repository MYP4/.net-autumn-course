using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.BL.Users.Entities;
using OnlineCinema.Context.Entities;


namespace OnlineCinema.BL.Users;

public class UserManager : IUserManager
{
    private readonly UserManager<UserEntity> userManager;
    private readonly IMapper _mapper;

    public UserManager(UserManager<UserEntity> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserModel> CreateUser(CreateUserModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
        {
            throw new Exception($"User with {model.Email} already exists.");
        }


        UserEntity userEntity = new UserEntity()
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            Patronymic = model.Patronymic,
            SecondName = model.SecondName,
            Birthday = model.Birthday,
        };

        var createUserResult = await userManager.CreateAsync(userEntity, model.Password);

        if (!createUserResult.Succeeded)
        {
            throw new Exception(String.Join(", ", createUserResult.Errors.Select(x => x.Description)));
        }

        return _mapper.Map<UserModel>(userEntity);
    }


    public async Task UpdateUser(Guid id, UpdateUserModel model)
    {
        //    var entity = _usersRepository.GetByGuid(id);

        //    if (entity == null)
        //    {
        //        throw new ArgumentException("User not found");
        //    }

        //    entity.FirstName = model.FirstName;
        //    entity.SecondName = model.SecondName;


        //    _usersRepository.Save(entity);

        //    return _mapper.Map<UserModel>(entity);
    }


    public async Task DeleteUser(Guid id)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.ExternalId == id);
        if (user == null)
        {
            throw new Exception($"User with Id = {id} not found.");
        }

        var deleteUserResult = await userManager.DeleteAsync(user);

        if (!deleteUserResult.Succeeded)
        {
            throw new Exception(String.Join(", ", deleteUserResult.Errors.Select(x => x.Description)));
        }
    }
}
