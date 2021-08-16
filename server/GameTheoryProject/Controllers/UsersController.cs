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
        public async Task<WebResponse<string>> Login([FromBody] UserLoginDto dto)
        {
            var accessToken = await _userService.LogInUserAsync(dto.Username, dto.Password);
            return new WebResponse<string>
            {
                Success = true,
                Data = accessToken,
            };
        }
        
        [HttpPost("register")]
        public async Task<WebResponse<string>> Register([FromBody] UserSignInDto dto)
        {
            var accessToken = await _userService.SignInUserAsync(dto.Username, dto.Password);
            return new WebResponse<string>
            {
                Success = true,
                Data = accessToken,
            };
        }

        [Authorize]
        [HttpGet("secret")]
        public string Secret()
        {
            return "secret string";
        }
    }
}