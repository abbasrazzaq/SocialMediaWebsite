using SocialMediaWebsite.Server.Controllers;
using SocialMediaWebsite.Server.Data;
using SocialMediaWebsite.Server.DTOs;
using SocialMediaWebsite.Server.Models;
using System.Data;

namespace SocialMediaWebsite.Server.Services
{
    public class UserProfileService
    {
        private readonly AppDbContext _context;

        public UserProfileService(AppDbContext context) => _context = context;

        public async Task<UserProfile> GetUserProfileInfo(int userId)
        {
            var userProfile = await _context.UserProfile.FindAsync(userId);
            return userProfile;
        }

        public UserProfileDto GetUserProfileDto(UserProfile userProfile)
        {
            return new UserProfileDto
            {
                Id = userProfile.Id,
                Username = userProfile.Username,
                Fullname = userProfile.Fullname,
                Age = userProfile.Age,
                Location = userProfile.Location,
                Workplace = userProfile.Workplace,
                Hometown = userProfile.Hometown,
                StudiedAt = userProfile.StudiedAt
            };
        }
    }
}
