using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.Constants;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Models;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class CurrencyConverterViewModel : ObservableObject
    {
        private readonly ICoinsService _coinService;
        private readonly IMessageService _messageService;

        public List<Currency> Currencies => CurrencyCatalog.All;

        public CurrencyConverterViewModel(ICoinsService coinService, IMessageService messageService)
        {
            _coinService = coinService;
            _messageService = messageService;
            _amountToConvert = 1;
            SelectedCurrency = Currencies.FirstOrDefault(c => c.Code == "usd");
        }

        [ObservableProperty]
        private decimal? _convertedValue;

        [ObservableProperty]
        private Currency? _selectedCurrency;

        [ObservableProperty]
        private decimal? _amountToConvert;

        public async Task ConvertCurrency(string coinId)
        {
            if (!AmountToConvert.HasValue) return;
            if (SelectedCurrency is null) return;
            if (string.IsNullOrEmpty(SelectedCurrency.Code)) return;

            var result = await _coinService
                .ConvertCurrencyAsync(coinId, AmountToConvert.Value, SelectedCurrency.Code);

            result.Match(
                onSuccess: convertedValue =>
                {
                    ConvertedValue = convertedValue;
                    return true;
                },
                onFailure: error =>
                {
                    _messageService.ShowError(
                        $"Failed to convert currency. Details: {error.Description}", $"Error {error.Code}");
                    return false;
                });
        }
    }
}
