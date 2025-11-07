using Microsoft.EntityFrameworkCore;
using SocialMediaWebsite.Server.Models;

namespace SocialMediaWebsite.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<UserProfile> UserProfile { get; set; }
        
        public DbSet<Friend> FriendsTable { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Friend>()
                .HasKey(f => new { f.UserId, f.FriendId });

            model.Entity<Friend>()
                .HasOne(f => f.UserProfile)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Friend>()
                .HasOne(f => f.FriendProfile)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
