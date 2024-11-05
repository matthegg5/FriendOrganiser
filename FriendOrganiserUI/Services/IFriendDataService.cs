using FriendOrganiser.Model;

namespace FriendOrganiserUI.Services
{
    public interface IFriendDataService
    {
        Task<IEnumerable<Friend>> GetAll();
        Task<Friend> GetFriendById(int friendId);
    }
}
