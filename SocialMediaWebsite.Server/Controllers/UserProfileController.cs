using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebsite.Server.Controllers
{
    public class UserProfileInfo
    {
        [Key]
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Fullname { get; set; }
        public int Age { get; set; }
        public required string Location { get; set; }
        public required string Workplace { get; set; }
        public required string Hometown { get; set; }
        public required string StudiedAt { get; set; }
    };

    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly UserProfileService _userProfileService;
        public UserProfileController(UserProfileService userProfileService) => _userProfileService = userProfileService;

        [HttpGet("getprofileinfo")]
        public async Task<IActionResult> GetProfileInfo()
        {
            var userProfile = await _userProfileService.GetUserProfileInfo(1);
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
