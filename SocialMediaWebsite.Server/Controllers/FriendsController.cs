using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetFriends()
        {
            // Placeholder implementation
            var friendsList = new[]
            {
                new { Username = "bigjim", Fullname = "Jim Bean Bob" },
                new { Username = "junespring", Fullname = "June Taylor" }
            };
            return Ok(friendsList);
        }

    }
}
