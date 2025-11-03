using Microsoft.EntityFrameworkCore;
using SocialMediaWebsite.Server.Models;

namespace SocialMediaWebsite.Server
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options)
            : base(options)
        { }

        public DbSet<UserProfileInfo> UserProfile { get; set; }
        
        public DbSet<Friend> FriendsTable { get; set; }
    }
}
