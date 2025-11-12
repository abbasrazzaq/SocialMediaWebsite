using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.DTOs.ApiRequests;
using SocialMediaWebsite.Server.Services;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly UserProfileService _userProfileService;
        public UserProfileController(UserProfileService userProfileService) => _userProfileService = userProfileService;


        [HttpPost("createaccount")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            var result = await _userProfileService.CreateAccount(_userProfileService.GetUserProfileDto(request));
            return Ok(result);
        }

        [HttpGet("getprofileinfo")]
        public async Task<IActionResult> GetProfileInfo([FromQuery] int userId)
        {
            var userProfile = await _userProfileService.GetUserProfileInfo(userId);
            if(userProfile != null)
            {
                var userProfileDto = _userProfileService.GetUserProfileDto(userProfile);
                return Ok(userProfileDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
