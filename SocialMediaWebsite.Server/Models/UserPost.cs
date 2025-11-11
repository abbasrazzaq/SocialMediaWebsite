namespace SocialMediaWebsite.Server.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
