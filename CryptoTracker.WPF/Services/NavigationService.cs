using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.Services
{
    internal partial class NavigationService : ObservableObject, INavigationService
    {
        [ObservableProperty]
        private ObservableObject? _currentViewModel;
        private readonly Func<Type, ObservableObject> _viewModelsFactory;

        public NavigationService(Func<Type, ObservableObject> viewModelsFactory)
        {
            _viewModelsFactory = viewModelsFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        {
            ObservableObject viewModel = _viewModelsFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
    }
}
