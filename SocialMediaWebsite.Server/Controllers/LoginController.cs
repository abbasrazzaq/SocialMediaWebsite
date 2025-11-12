using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.Services;

namespace SocialMediaWebsite.Server.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService) => _loginService = loginService;

        [HttpPost("validatelogin")]
        public async Task<IActionResult> ValidateLogin([FromBody] LoginRequest loginRequest)
        {
            var result = await _loginService.ValidateLogin(loginRequest.Username, loginRequest.Password);
            return Ok(result);
        }
    }
}
