using FriendOrganiser.Model;
using System.Collections.ObjectModel;

namespace FriendOrganiserUI.ViewModels
{
    public interface INavigationViewModel
    {
        Task LoadAsync();
    }
}