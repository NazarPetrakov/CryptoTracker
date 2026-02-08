using CommunityToolkit.Mvvm.ComponentModel;

namespace CryptoTracker.WPF.Interfaces
{
    public interface INavigationService
    {
        ObservableObject CurrentViewModel { get; }
        void NavigateTo<TViewModel>() where TViewModel : ObservableObject;
    }
}
