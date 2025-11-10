namespace SocialMediaWebsite.Server.DTOs.Requests
{
    public class RemoveFriendRequest
    {
        public required int UserId { get; set; }
        public required int FriendId { get; set; }
    }
}
