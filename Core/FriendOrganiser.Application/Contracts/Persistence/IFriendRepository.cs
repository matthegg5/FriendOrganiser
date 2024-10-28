using FriendOrganiser.Domain.Entities;

namespace FriendOrganiser.Application.Contracts.Persistence
{
    public interface IFriendRepository : IAsyncRepository<Friend>
    {
	Task<bool> IsFriendIdUnique(int friendID);   
    }
}
