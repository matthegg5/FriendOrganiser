﻿using FriendOrganiser.Model;
using FriendOrganiserUI.Services;
using System.Collections.ObjectModel;

namespace FriendOrganiserUI.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        private ILookupDataService _lookupService;

        public ObservableCollection<LookupItem> Friends { get; private set; }

        public NavigationViewModel(ILookupDataService lookupService)
        {
            _lookupService = lookupService;
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
    }
}
