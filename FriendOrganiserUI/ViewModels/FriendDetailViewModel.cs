using FriendOrganiser.Model;
using FriendOrganiserUI.Services;

namespace FriendOrganiserUI.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _friendDataService;
        public Friend Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        private Friend _friend;

        public FriendDetailViewModel(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await _friendDataService.GetFriendById(friendId);
        }
    }
}
