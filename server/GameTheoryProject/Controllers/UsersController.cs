using System.Threading.Tasks;
using GameTheoryProject.Domain.Services;
using GameTheoryProject.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTheoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<string> Login([FromBody] UserLoginDto dto)
        {
            return await _userService.LogInUserAsync(dto.Username, dto.Password);
        }
        
        [HttpPost("register")]
        public async Task<string> Register([FromBody] UserSignInDto dto)
        {
            return await _userService.SignInUserAsync(dto.Username, dto.Password);
        }

        [Authorize]
        [HttpGet("secret")]
        public string Secret()
        {
            return "secret string";
        }
    }
}