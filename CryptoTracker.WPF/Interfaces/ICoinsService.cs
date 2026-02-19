using CryptoTracker.WPF.Helpers.QueryParameters;
using CryptoTracker.WPF.Helpers.ResultT;
using CryptoTracker.WPF.Models;

namespace CryptoTracker.WPF.Interfaces
{
    internal interface ICoinsService
    {
        Task<ResultT<IEnumerable<Coin>>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null);
        Task<ResultT<DetailedCoin>> GetCoinByIdAsync(string coinId, CoinByIdParams? queryParams = null);
        Task<ResultT<decimal>> ConvertCurrencyAsync(
            string fromCurrencyId, decimal amount, string toVsCurrency);
    }
}
