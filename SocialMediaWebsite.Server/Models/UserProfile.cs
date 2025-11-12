namespace SocialMediaWebsite.Server.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Workplace { get; set; }
        public string Hometown { get; set; }
        public string StudiedAt { get; set; }

        public ICollection<Friend> Friends { get; set; } = new List<Friend>();
        public ICollection<UserPost> Posts { get; set; } = new List<UserPost>();
    }
}
