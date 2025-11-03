using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getprofileinfo")]
        public async Task<IActionResult> GetProfileInfo([FromQuery] int userId)
        {
            var userProfile = await _userProfileService.GetUserProfileInfo(userId);
            if(userProfile != null)
            {
                return Ok(userProfile);
            }
            else
            {
                return NotFound();
            }

                //return Ok(
                //    new UserProfileInfo
                //    {
                //        Username = "abbashols",
                //        Fullname = "Abbas Razzaq",
                //        Age = 37,
                //        Location = "Ho Chi Minh City",
                //        Workplace = "Senior Software Developer at Surpass Assessment",
                //        Hometown = "Bradford",
                //        StudiedAt = "University of Derby"
                //    }
                //);
        }
    }
}
