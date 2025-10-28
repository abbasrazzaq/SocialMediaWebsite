using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWebsite.Server.Controllers
{
    public class UserProfileInfo
    {
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
        [HttpGet("getprofileinfo")]
        public IActionResult GetProfileInfo()
        {
            return Ok( 
                new UserProfileInfo
                {
                    Username = "abbashols",
                    Fullname = "Abbas Razzaq",
                    Age = 37,
                    Location = "Ho Chi Minh City",
                    Workplace = "Senior Software Developer at Surpass Assessment",
                    Hometown = "Bradford",
                    StudiedAt = "University of Derby"
                }
            );
        }
    }
}
