using CommunityToolkit.Mvvm.ComponentModel;

namespace CryptoTracker.WPF.Interfaces
{
    internal interface INavigationService
    {
        ObservableObject CurrentViewModel { get; }
        void NavigateTo(Type viewModelType);
        void NavigateTo<TViewModel, TParameters>(TParameters parameters)
            where TViewModel : ObservableObject
            where TParameters : IViewModelParameters;
        void NavigateTo<TViewModel>()
            where TViewModel : ObservableObject;
    }
}
