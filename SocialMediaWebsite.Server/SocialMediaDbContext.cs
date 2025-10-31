using Microsoft.EntityFrameworkCore;

namespace SocialMediaWebsite.Server
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options)
            : base(options)
        { }

        public DbSet<Controllers.UserProfileInfo> UserProfile { get; set; }
    }
}
