using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineCinema.BL.Entities.Auth.Entities;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.BL.Entities.Auth;

internal class AuthProvider : IAuthProvider
{

    private readonly SignInManager<UserEntity> _signInManager;












    public Task<TokenResponse> AuthorizeUser(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<TokenResponse> RegisterUser(string email, string password, string name, string surname)
    {
        throw new NotImplementedException();
    }
}
