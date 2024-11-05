using FriendOrganiser.Model;

namespace FriendOrganiserUI.Services
{
    public interface ILookupDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}