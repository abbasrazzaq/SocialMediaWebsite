using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.Models;
using SocialMediaWebsite.Server.Services;

namespace SocialMediaWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private readonly FriendsService _friendService;

        public FriendsController(FriendsService friendsService) => _friendService = friendsService;

        [HttpGet]
        public async Task<ActionResult> GetFriends()
        {
            var friendsList = _friendService.GetFriendsList(1);

            return Ok(friendsList);
        }

    }
}
