using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
