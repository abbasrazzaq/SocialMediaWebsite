namespace SocialMediaWebsite.Server.DTOs.ApiRequests
{
    public class CreateAccountRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Workplace { get; set; }
        public string Hometown { get; set; }
        public string StudiedAt { get; set; }
    }
}
