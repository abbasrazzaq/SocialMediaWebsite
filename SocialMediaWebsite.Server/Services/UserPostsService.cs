using Microsoft.EntityFrameworkCore;
using SocialMediaWebsite.Server.Data;
using SocialMediaWebsite.Server.DTOs;
using SocialMediaWebsite.Server.Models;

namespace SocialMediaWebsite.Server.Services
{
    public class UserPostsService
    {
        private readonly AppDbContext _context;

        public UserPostsService(AppDbContext context) => _context = context;

        public async Task<List<UserPostDto>> GetUserPosts(int userId)
        {
            var user = await _context.UserProfile
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return new List<UserPostDto>();

            var posts = user.Posts
                .Select(p => new UserPostDto
                {
                    Id = p.Id,
                    Text = p.Text
                });

            return posts.ToList();
        }
    }
}
