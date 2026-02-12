using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.QueryParameters;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Models;
using System.Collections.ObjectModel;

namespace CryptoTracker.WPF.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Coin> _coins;
        [ObservableProperty]
        private bool _isLoading;
        private readonly ICoinsService _coinService;
        private readonly IMessageService _messageService;

        public HomeViewModel(ICoinsService coinService, IMessageService messageService)
        {
            _coinService = coinService;
            _messageService = messageService;
            _coins = new ObservableCollection<Coin>();
        }
        [RelayCommand]
        private void OpenDetail(Coin? coin)
        {
            if (coin is null)
            {
                return;
            }

            _messageService.ShowMessage(coin.Name);
        }
        [RelayCommand]
        private async Task Initialize()
        {
            IsLoading = true;
            try
            {
                var coins = await GetPaginatedCoinsAsync(15, 1);
                Coins.Clear();
                foreach (var coin in coins)
                {
                    Coins.Add(coin);
                }
            }
            catch (Exception e)
            {
                _messageService.ShowError($"Failed to load coins, Details:{e.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }
        private async Task<IEnumerable<Coin>> GetPaginatedCoinsAsync(int perPage, int page)
        {
            var coinDtos = await _coinService.GetCoinsWithMarketDataAsync(new CoinWithMarketDataParams()
            {
                PerPage = perPage,
                Page = page,
            });

            return coinDtos.Select(c => c.ToModel());

        }
    }
}
