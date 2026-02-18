using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.Navigation.Parameters;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Models;
using System.Diagnostics;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class DetailedCoinViewModel
        : ObservableObject, IParameterizable<DetailedCoinViewModelParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly ICoinsService _coinService;
        private readonly IMessageService _messageService;

        public DetailedCoinViewModel(INavigationService navigationService,
            ICoinsService coinService, IMessageService messageService)
        {
            _navigationService = navigationService;
            _coinService = coinService;
            _messageService = messageService;
        }

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private DetailedCoin? _coin;

        [ObservableProperty]
        private TickerDto? _selectedMarket;
        public DetailedCoinViewModelParameters ViewModelParameters { get; private set; }

        [RelayCommand]
        private void OpenMarketPage()
        {
            if (SelectedMarket is not null && SelectedMarket.TradeUrl is not null)
            {
                string url = SelectedMarket.TradeUrl;
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
        }
        [RelayCommand]
        private async Task Initialize()
        {
            await LoadCoinById(ViewModelParameters.Id);
        }

        [RelayCommand]
        private void GoBack()
        {
            _navigationService.NavigateTo<HomeViewModel>();
        }

        [RelayCommand]
        private async Task Reload()
        {
            if (IsLoading) return;
            await LoadCoinById(ViewModelParameters.Id);
        }

        public async Task LoadCoinById(string coinId)
        {
            IsLoading = true;

            var result = await _coinService.GetCoinByIdAsync(coinId);

            result.Match(
                onSuccess: () =>
            {
                    Coin = result.Value;
                    return true;
                },
                onFailure: error =>
            {
                    _messageService.ShowError(
                        $"Failed to load coin. Details: {error.Description}", $"Error {error.Code}");
                    return false;
                });

                IsLoading = false;
            }
        }
        public void InitializeParameters(DetailedCoinViewModelParameters viewModelParameters)
        {
            ViewModelParameters = viewModelParameters;
        }
    }
}
