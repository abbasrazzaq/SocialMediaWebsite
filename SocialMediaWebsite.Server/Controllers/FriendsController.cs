using Microsoft.AspNetCore.Mvc;
using SocialMediaWebsite.Server.DTOs.Requests;
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
        public async Task<ActionResult> GetFriends([FromQuery] int userId)
        {
            var friendsList = _friendService.GetFriendsList(userId);
            return Ok(friendsList);
        }

        [HttpPost("addfriend")]
        public async Task<ActionResult> AddFriend([FromBody] FriendChangeRequest request)
        {
            var result = await _friendService.AddFriend(request.UserId, request.FriendId);
            // TODO: Check the result (or on the UI)
            return Ok(result);
        }

        [HttpPost("removefriend")]
        public async Task<ActionResult> RemoveFriend([FromBody] FriendChangeRequest request)
        {
            var result = await _friendService.RemoveFriend(request.UserId, request.FriendId);
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
