#nullable disable
#pragma warning disable CS8603 
using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Domain.Entities;

namespace FriendOrganiser.Infrastructure.Persistence.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(FriendOrganiserDbContext dbContext) : base(dbContext)
        {
            
        }

        public Task<bool> IsFriendIdUnique(int friendId)
        {
            var matches = _dbContext.Friend.Any(p => p.Id.Equals(friendId));
            return Task.FromResult(matches);
        }
    }
}