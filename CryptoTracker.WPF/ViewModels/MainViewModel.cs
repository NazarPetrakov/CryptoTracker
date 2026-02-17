using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Helpers.Navigation;
using CryptoTracker.WPF.Interfaces;
using System.Collections.ObjectModel;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private INavigationService _navigationService;

        [ObservableProperty]
        private NavigationItem _selectedNavItem;

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem("Home", typeof(HomeViewModel)),
                new NavigationItem("Settings", typeof(SettingsViewModel))
            };
            SelectedNavItem = NavigationItems[0];
        }

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        partial void OnSelectedNavItemChanged(NavigationItem value)
        {
            if (value.ViewModelType == null ||
                NavigationService.CurrentViewModel?.GetType() == value.ViewModelType)
            {
                return;
            }

            NavigationService.NavigateTo(value.ViewModelType);
        }
    }
}
