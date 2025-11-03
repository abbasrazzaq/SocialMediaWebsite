using SocialMediaWebsite.Server.Models;

namespace SocialMediaWebsite.Server.Services
{
    public class FriendsService
    {
        private readonly SocialMediaDbContext _context;

        public FriendsService(SocialMediaDbContext context) => _context = context;

        public List<FriendInfo> GetFriendsList(int userId)
        {
            var friends =       from f in _context.FriendsTable
                                where f.UserId == userId
                                join u in _context.UserProfile on f.FriendId equals u.Id
                                select new FriendInfo {
                                    FriendId = u.Id,
                                    Username = u.Username,
                                    Fullname = u.Fullname
                                };

            return friends.ToList();
        }
    }
}
