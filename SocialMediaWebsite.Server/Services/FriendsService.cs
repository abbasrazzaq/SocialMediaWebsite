using Microsoft.EntityFrameworkCore;
using SocialMediaWebsite.Server.Data;
using SocialMediaWebsite.Server.DTOs;
using SocialMediaWebsite.Server.Models;

namespace SocialMediaWebsite.Server.Services
{
    public class FriendsService
    {
        private readonly AppDbContext _context;

        public FriendsService(AppDbContext context) => _context = context;

        public List<FriendDto> GetFriendsList(int userId)
        {
            var friends =       from f in _context.FriendsTable
                                where f.UserId == userId
                                join u in _context.UserProfile on f.FriendId equals u.Id
                                select new FriendDto
                                {
                                    Id = f.FriendId,
                                    Fullname = u.Fullname,
                                    Username = u.Username,
                                };

            return friends.ToList();
        }

        public async Task<List<FriendDto>> GetPeopleMayKnow(int userId)
        {
            var peopleMayKnow = from f in _context.UserProfile
                                where f.Id != userId && !_context.FriendsTable.Any(fr => fr.UserId == userId && fr.FriendId == f.Id)
                                select new FriendDto 
                                { 
                                    Id = f.Id, 
                                    Username = f.Username,
                                    Fullname = f.Fullname 
                                };

            return await peopleMayKnow.ToListAsync();
        }

        public async Task<bool> AddFriend(int userId, int newFriendId)
        {
            _context.FriendsTable.Add(new Friend { UserId = userId, FriendId = newFriendId });
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveFriend(int userId, int friendId)
        {
            var friend = _context.FriendsTable.FirstOrDefault(f => f.UserId == userId && f.FriendId == friendId);
            if (friend == null)
            {
                // TODO: LOG error: Friend entry not found
                return false;
            }
            _context.FriendsTable.Remove(friend);
            return  _context.SaveChanges() > 0;
        }
    }
}
