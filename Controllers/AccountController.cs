using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ReactMVC.Models;
using ReactMVC.Repository.Contracts;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

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

                return Ok(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error: {nameof(Login)}");
                //throw;
                return Problem($"Error: {nameof(Login)}", statusCode: 500);
            }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _unitOfWork.Users.GetAsync(q => q.IdInteger == id);
                var result = _mapper.Map<APIUser>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error: {nameof(Login)}");
                //throw;
                return Problem($"Error: {nameof(Login)}", statusCode: 500);
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.GetAsync(q => q.IdInteger == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
