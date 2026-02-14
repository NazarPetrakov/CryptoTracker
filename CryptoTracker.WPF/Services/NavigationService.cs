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

        public void NavigateTo<TViewModel, TParameters>(TParameters parameters)
            where TViewModel : ObservableObject
            where TParameters : IViewModelParameters
        {
            NavigateTo<TViewModel>();

            if (CurrentViewModel is IParameterizable<TParameters> cvm)
            {
                cvm.InitializeParameters(parameters);
            }
        }
        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        {
            SetCurrentViewModel(typeof(TViewModel));
        }
        public void NavigateTo(Type viewModelType)
        {
            SetCurrentViewModel(viewModelType);
        }

        private void SetCurrentViewModel(Type viewModelType)
        {
            ObservableObject viewModel = _viewModelsFactory.Invoke(viewModelType);
            CurrentViewModel = viewModel;
        }
    }
}
