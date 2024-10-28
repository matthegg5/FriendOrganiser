using FriendOrganiser.Model;
using FriendOrganiserUI.Data;
using System.Collections.ObjectModel;

namespace FriendOrganiserUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendDataService _friendDataService;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }

        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }

        public async Task Load()
        {
            var friends = await _friendDataService.GetAll();
            Friends.Clear();

            foreach (var friend in friends) 
            {
                Friends.Add(friend);
            }
        }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set 
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }
    }
}
