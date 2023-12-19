using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCinema.Api.Controllers.User.Models;
using OnlineCinema.BL.Entities.Auth;
using OnlineCinema.BL.Users;
using OnlineCinema.BL.Users.Entities;

namespace OnlineCinema.Api.Controllers.User;


[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAuthProvider _authProvider;
    private readonly IUserProvider _userProvider;
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UsersController(
        IAuthProvider authProvdider, 
        IUserProvider usersProvider,
        IUserManager userManager,
        IMapper mapper, 
        ILogger<UsersController> logger)
    {
        _authProvider = authProvdider;
        _userProvider = usersProvider;
        _userManager = userManager;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromQuery] string email, [FromQuery] string password)
    {
        try
        {
            TokenResponse tokens = await _authProvider.AuthorizeUser(email, password);
            return Ok(tokens);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = await _userManager.CreateUser(_mapper.Map<CreateUserModel>(request));

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        IEnumerable<UserModel> users =  await _userProvider.GetUsers();

        return Ok(new UsersListResponce()
        {
            Users = users.ToList()
        });
    }

    [Authorize]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        try
        {
            UserModel user = await _userProvider.GetUserInfo(id);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    //[HttpPut]
    //[Route("{id}")]
    //public IActionResult UpdateUserInfo([FromRoute] Guid id, UpdateUserRequest request)
    //{
    //    try
    //    {
    //        UserModel user = _userManager.UpdateUser(id, _mapper.Map<UpdateUserModel>(request));
    //        return Ok(user);
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        _logger.LogError(ex.ToString());
    //        return NotFound(ex.Message);
    //    }
    //}

    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        try
        {
            await _userManager.DeleteUser(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}

