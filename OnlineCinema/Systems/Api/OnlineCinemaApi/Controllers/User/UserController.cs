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
public class UserController : ControllerBase
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;
        private readonly IUserManager _userManager;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(IAuthProvider authProvdider, IUserManager usersManager, IUserProvider usersProvider,
            IMapper mapper, ILogger<UsersController> logger)
        {
            _authProvider = authProvdider;
            _userManager = usersManager;
            _userProvider = usersProvider;
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
                await _authProvider.RegisterUser(request.Email, request.Password, request.FirstName, request.SecondName);
                UserModel user = _userManager.CreateUser(_mapper.Map<CreateUserModel>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserModel> users = _userProvider.GetUsers();

            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                UserModel user = _userProvider.GetUserInfo(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserInfo([FromRoute] Guid id, UpdateUserRequest request)
        {
            try
            {
                UserModel user = _userManager.UpdateUser(id, _mapper.Map<UpdateUserModel>(request));
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                _userManager.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }
    }
}
