using FriendOrganiser.Model;
using FriendOrganiserUI.Events;
using FriendOrganiserUI.Services;
using System.Collections.ObjectModel;

namespace FriendOrganiserUI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookupDataService _lookupService;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<LookupItem> Friends { get; private set; }

        public NavigationViewModel(ILookupDataService lookupService, IEventAggregator eventAggregator)
        {
            _lookupService = lookupService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _lookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(item);
            }
        }

        private LookupItem _selectedFriend;

        public LookupItem SelectedFriend
        {
            get { return _selectedFriend; }
            set 
            { 
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    // publish the OpenFriendDetailViewEvent and send the selected friend Id with the message to the EventAggregator
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
                }
            }
        }

    }
}
