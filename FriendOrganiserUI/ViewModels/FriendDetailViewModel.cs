using FriendOrganiser.Model;
using FriendOrganiserUI.Events;
using FriendOrganiserUI.Services;
using System.Security.Cryptography.Xml;
using System.Windows.Input;

namespace FriendOrganiserUI.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _friendDataService;
        private readonly IEventAggregator _eventAggregator;

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

        public FriendDetailViewModel(IFriendDataService friendDataService, IEventAggregator eventAggregator)
        {
            _friendDataService = friendDataService;
            _eventAggregator = eventAggregator;

            // subscribe to the OpenFriendDetailViewEvent and run OnOpenFriendDetailView
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);

            // initialises a command object to see if the Friend can be saved first (for validation etc.) when the command is executed and then
            // calls the FriendDataService to save the Friend object to the database via the API.
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            // Validate Friend here
            return true;
        }

        private async void OnSaveExecute()
        {
            await _friendDataService.Save(Friend);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await _friendDataService.GetFriendById(friendId);
        }

        public ICommand SaveCommand { get; }
    }
}
