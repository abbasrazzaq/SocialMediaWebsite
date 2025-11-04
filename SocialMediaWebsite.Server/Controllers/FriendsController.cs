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

        [HttpGet("getfriends")]
        public async Task<ActionResult> GetFriends()
        {
            var friendsList = _friendService.GetFriendsList(1);

            return Ok(friendsList);
        }

        [HttpPost("removefriend")]
        public async Task<ActionResult> RemoveFriend([FromBody] Friend friend)
        {
            var result = await _friendService.RemoveFriend(friend.UserId, friend.FriendId);

            if(result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
