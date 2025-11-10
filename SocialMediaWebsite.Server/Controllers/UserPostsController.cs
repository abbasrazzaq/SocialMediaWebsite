using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.DTOs;
using SocialMediaWebsite.Server.Services;

namespace SocialMediaWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostsController : Controller
    {
        private readonly UserPostsService _userPostsService;

        public UserPostsController(UserPostsService userPostsService) => _userPostsService = userPostsService;

        [HttpGet("getusersposts")]
        public async Task<ActionResult<List<UserPostDto>>> GetUsersPosts([FromQuery] int userId)
        {
            var userPosts = await _userPostsService.GetUserPosts(userId);
            return Ok(userPosts);
        }
    }
}
