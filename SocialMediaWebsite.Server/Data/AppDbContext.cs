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

        public DbSet<UserPost> UserPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Friend
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
            #endregion

            #region UserPost
            model.Entity<UserPost>()
                .HasOne(p => p.UserProfile)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<UserPost>()
                .ToTable("UserPost");

            model.Entity<UserPost>()
                .Property(p => p.Text)
                .HasMaxLength(500)
                .IsRequired(false);

            model.Entity<UserPost>()
                .HasOne(p => p.UserProfile)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
