using SocialMediaWebsite.Server.Controllers;
using System.Data;

namespace SocialMediaWebsite.Server.Services
{
    public class UserProfileService
    {
        private readonly SocialMediaDbContext _context;

        public UserProfileService(SocialMediaDbContext context) => _context = context;

        public async Task<Models.UserProfileInfo> GetUserProfileInfo(int userId)
        {
            var userProfile = await _context.UserProfile.FindAsync(userId);
            return userProfile;
        }
    }
}
