using CommunityToolkit.Mvvm.ComponentModel;

namespace CryptoTracker.WPF.Interfaces
{
    internal interface INavigationService
    {
        ObservableObject CurrentViewModel { get; }
        void NavigateTo<TViewModel>() where TViewModel : ObservableObject;
        void NavigateTo(Type viewModelType);
    }
}
