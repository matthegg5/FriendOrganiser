using System.Threading.Tasks;

namespace FriendOrganiserUI.ViewModels
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}