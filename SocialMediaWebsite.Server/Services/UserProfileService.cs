using SocialMediaWebsite.Server.Controllers;
using SocialMediaWebsite.Server.Data;
using SocialMediaWebsite.Server.DTOs;
using SocialMediaWebsite.Server.DTOs.ApiRequests;
using SocialMediaWebsite.Server.Models;
using System.Data;

namespace SocialMediaWebsite.Server.Services
{
    public class UserProfileService
    {
        private readonly AppDbContext _context;

        public UserProfileService(AppDbContext context) => _context = context;

        public async Task<bool> CreateAccount(UserProfileDto userProfile)
        {
            _context.UserProfile.Add(new UserProfile
            {
                Username = userProfile.Username,
                Fullname = userProfile.Fullname,
                Age = userProfile.Age,
                Location = userProfile.Location,
                Workplace = userProfile.Workplace,
                Hometown = userProfile.Hometown,
                StudiedAt = userProfile.StudiedAt
            });
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserProfile> GetUserProfileInfo(int userId)
        {
            var userProfile = await _context.UserProfile.FindAsync(userId);
            return userProfile;
        }

        public UserProfileDto GetUserProfileDto(CreateAccountRequest request)
        {
            return new UserProfileDto
            {
                Username = request.Username,
                Fullname = request.Fullname,
                Age = request.Age,
                Location = request.Location,
                Workplace = request.Workplace,
                Hometown = request.Hometown,
                StudiedAt = request.StudiedAt
            };
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
