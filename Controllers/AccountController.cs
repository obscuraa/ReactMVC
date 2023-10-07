using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReactMVC.Models;
using ReactMVC.Services;
using ReactMVC.Services.Contracts;

namespace ReactMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<APIUser> _userManager;
        //private readonly SignInManager<APIUser> _signInManager;
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;
        private IMapper _mapper;

        public AccountController(UserManager<APIUser> userManager, /*SignInManager<APIUser> signInManager,*/ IAuthManager authManager, ILogger<AccountController> logger, IMapper Mapper)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _authManager = authManager;
            _logger = logger;
            _mapper = Mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registrating attempt by {userDto.FirstName} { userDto.LastName} { userDto.UserEmail}");
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<APIUser>(userDto);
                user.UserName = userDto.UniqueUsername;
                user.Email = userDto.UserEmail;
                var result = await _userManager.CreateAsync(user, userDto.UserPassword);

                if(!result.Succeeded)
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error: {nameof(Register)}");
                //throw;
                return Problem($"Error: {nameof(Register)}", statusCode: 500);
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userDto)
        {
            _logger.LogInformation($"Login attempt by {userDto.UserEmail}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(userDto))
                {
                    return Unauthorized();
                }

                return Ok(new { Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error: {nameof(Login)}");
                //throw;
                return Problem($"Error: {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
