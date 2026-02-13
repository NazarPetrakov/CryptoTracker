using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Helpers.Navigation;
using CryptoTracker.WPF.Interfaces;
using System.Collections.ObjectModel;

namespace CryptoTracker.WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private INavigationService _navigationService;
        [ObservableProperty]
        private NavigationItem _selectedNavItem;
        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem("Home", typeof(HomeViewModel)),
                new NavigationItem("Settings", typeof(DetailedCoinViewModel))
            };
            SelectedNavItem = NavigationItems[0];
        }

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
