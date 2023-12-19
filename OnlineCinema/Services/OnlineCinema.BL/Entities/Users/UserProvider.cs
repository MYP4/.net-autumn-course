using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineCinema.BL.Users.Entities;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.BL.Users;

public class UserProvider : IUserProvider
{
    private readonly UserManager<UserEntity> userManager;
    private readonly IMapper _mapper;

    public UserProvider(UserManager<UserEntity> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserModel> GetUserInfo(Guid id)
    {
        var User = await userManager.Users.Where(x => x.ExternalId == id).FirstOrDefaultAsync();
            

        if (User is null)
        {
            throw new ArgumentException("User not found");
        }

        return _mapper.Map<UserModel>(User);
    }


    public async Task<IEnumerable<UserModel>> GetUsers(UserModelFilter filter = null)
    {
        var firstName = filter?.FirstName;
        var secondName = filter?.SecondName;

        var currentDate = DateTime.UtcNow;

        var Users = userManager.Users
            .Where(x => (firstName == null || x.FirstName.Equals(firstName)) &&
                         (secondName == null || x.SecondName.Equals(secondName)));


        return _mapper.Map<IEnumerable<UserModel>>(Users);
    }
}
