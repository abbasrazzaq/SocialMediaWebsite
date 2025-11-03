using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebsite.Server.Models
{
    public class UserProfileInfo
    {
        [Key]
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Fullname { get; set; }
        public int Age { get; set; }
        public required string Location { get; set; }
        public required string Workplace { get; set; }
        public required string Hometown { get; set; }
        public required string StudiedAt { get; set; }
    };
}
