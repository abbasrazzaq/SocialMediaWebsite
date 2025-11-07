namespace SocialMediaWebsite.Server.Models
{
    public class Friend
    {
        public required int UserId { get; set; }
        public required int FriendId { get; set; }

        public UserProfile UserProfile { get; set; }
        public UserProfile FriendProfile { get; set; }
    }
}
