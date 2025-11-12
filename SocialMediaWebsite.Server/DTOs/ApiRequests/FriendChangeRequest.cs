namespace SocialMediaWebsite.Server.DTOs.Requests
{
    public class FriendChangeRequest
    {
        public required int UserId { get; set; }
        public required int FriendId { get; set; }
    }
}
