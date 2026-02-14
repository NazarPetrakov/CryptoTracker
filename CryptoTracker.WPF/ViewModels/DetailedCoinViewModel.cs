using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Helpers.Navigation.Parameters;
using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class DetailedCoinViewModel
        : ObservableObject, IParameterizable<DetailedCoinViewModelParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly ICoinsService _coinService;

        public DetailedCoinViewModel(INavigationService navigationService, ICoinsService coinService)
        {
            _navigationService = navigationService;
            _coinService = coinService;
        }

        public DetailedCoinViewModelParameters ViewModelParameters { get; private set; }

        [ObservableProperty]
        private CoinByIdDto? _coinByIdDto;

        [RelayCommand]
        private async Task Initialize()
        {
            CoinByIdDto = await LoadCoinById(ViewModelParameters.Id);
        }

        [RelayCommand]
        private void GoBack()
        {
            _navigationService.NavigateTo<HomeViewModel>();
        }

        public async Task<CoinByIdDto> LoadCoinById(string coinId)
        {
            return await _coinService.GetCoinByIdAsync(coinId);
        }
        public void InitializeParameters(DetailedCoinViewModelParameters viewModelParameters)
        {
            ViewModelParameters = viewModelParameters;
        }
    }
}
