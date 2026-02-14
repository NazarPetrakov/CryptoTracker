using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.Navigation.Parameters;
using CryptoTracker.WPF.Helpers.QueryParameters;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Models;
using System.Collections.ObjectModel;

namespace CryptoTracker.WPF.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ICoinsService _coinService;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private PaginationViewModel _paginator;

        [ObservableProperty]
        private ObservableCollection<Coin> _coins;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private Coin? _selectedCoin;

        [ObservableProperty]
        private string? _symbolToSearch;

        public HomeViewModel(ICoinsService coinService,
            IMessageService messageService,
            INavigationService navigationService,
            PaginationViewModel paginationViewModel)
        {
            _coinService = coinService;
            _messageService = messageService;
            _navigationService = navigationService;
            _coins = new ObservableCollection<Coin>();

            Paginator = paginationViewModel;

            Paginator.SelectedPageSizeChanged += Paginator_SelectedPageSizeChanged;
        }

        [RelayCommand]
        private void OpenDetailedCoin()
        {
            if (SelectedCoin is null)
            {
                return;
            }

            _navigationService.NavigateTo<DetailedCoinViewModel>(
                new DetailedCoinViewModelParameters(SelectedCoin.Id));
        }

        [RelayCommand]
        private async Task Initialize()
        {
            if (Coins.Any()) return;

            await LoadPaginatedCoinsAsync(Paginator.SelectedPageSize);
        }

        [RelayCommand]
        private async Task ClearSearch()
        {
            SymbolToSearch = null;

            await SearchCoins();
        }

        [RelayCommand]
        private async Task SearchCoins()
        {
            await LoadCoinsAccordingToFiltersAsync(Paginator.SelectedPageSize, SymbolToSearch);
        }
        private async Task LoadCoinsAccordingToFiltersAsync(int selectedPageSize, string? symbolToSearch)
        {
            if (string.IsNullOrEmpty(symbolToSearch))
            {
                await LoadPaginatedCoinsAsync(selectedPageSize);
                return;
            }
            await LoadCoinsBySymbolAsync(symbolToSearch);
        }
        private async Task LoadPaginatedCoinsAsync(int perPage)
        {
            await LoadCoinsAsync(new CoinWithMarketDataParams
            {
                PerPage = perPage,
                Page = 1
            });
        }
        private async Task LoadCoinsBySymbolAsync(string searchSymbol)
        {
            await LoadCoinsAsync(new CoinWithMarketDataParams
            {
                IncludeTokens = IncludeTokens.All,
                Symbols = searchSymbol,
                PerPage = Paginator.SelectedPageSize,
                Page = 1
            });
        }
        private async void Paginator_SelectedPageSizeChanged(object? sender, int e)
        {
            await LoadCoinsAccordingToFiltersAsync(e, SymbolToSearch);
        }

        private async Task LoadCoinsAsync(CoinWithMarketDataParams coinParams)
        {
            IsLoading = true;
            try
            {
                var coinDtos = await _coinService.GetCoinsWithMarketDataAsync(coinParams);
                UpdateCoinList(coinDtos);
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
        private void UpdateCoinList(IEnumerable<CoinWithMarketDataDto> dtos)
        {
            Coins.Clear();
            foreach (var dto in dtos)
            {
                Coins.Add(dto.ToModel());
            }
        }


    }
}
