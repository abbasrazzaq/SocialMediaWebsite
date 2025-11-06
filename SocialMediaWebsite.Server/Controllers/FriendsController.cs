using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.Models;
using SocialMediaWebsite.Server.Services;

namespace SocialMediaWebsite.Server.Controllers
{
    public class AddFriend
    {
        public required int UserId { get; set; }
        public required int FriendId { get; set; }
    }

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

        [HttpPost("addfriend")]
        public async Task<ActionResult> AddFriend([FromBody] AddFriend addFriend)
        {
            var result = await _friendService.AddFriend(addFriend.UserId, addFriend.FriendId);
            // TODO: Check the result (or on the UI)
            return Ok(result);
        }

        [HttpPost("removefriend")]
        public async Task<ActionResult> RemoveFriend([FromBody] Friend friend)
        {
            var result = await _friendService.RemoveFriend(friend.UserId, friend.FriendId);
            return Ok(result);
        }

        [HttpGet("getpeoplemayknow")]
        public async Task<ActionResult> GetPeopleYouMayKnow([FromQuery] int userId)
        {
            var result = await _friendService.GetPeopleMayKnow(userId);
            return Ok(result);
        }

    }
}
