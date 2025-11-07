namespace SocialMediaWebsite.Server.DTOs.Requests
{
    public class AddFriendRequest
    {
        public required int UserId { get; set; }
        public required int FriendId { get; set; }
    }
}
