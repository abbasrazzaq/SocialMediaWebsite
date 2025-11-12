using Microsoft.EntityFrameworkCore;
using SocialMediaWebsite.Server.Data;

namespace SocialMediaWebsite.Server.Services
{
    public class LoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context) => _context = context;

        public async Task<bool> ValidateLogin(string username, string password)
        {
            var user = await _context.UserProfile
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
