using FriendOrganiser.Model;
using FriendOrganiserUI.Services;
using System.Collections.ObjectModel;

namespace FriendOrganiserUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailViewModel FriendDetailViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

        public async Task Load()
        {
            await NavigationViewModel.LoadAsync();
        }

    }
}
