using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Helpers.QueryParameters;

namespace CryptoTracker.WPF.Interfaces
{
    internal interface ICoinsService
    {
        Task<ResultT<IEnumerable<Coin>>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null);
        Task<ResultT<DetailedCoin>> GetCoinByIdAsync(string coinId, CoinByIdParams? queryParams = null);
    }
}
