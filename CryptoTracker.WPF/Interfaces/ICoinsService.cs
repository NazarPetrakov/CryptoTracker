using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Helpers.QueryParameters;

namespace CryptoTracker.WPF.Interfaces
{
    public interface ICoinsService
    {
        Task<IEnumerable<CoinWithMarketDataDto>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null);
    }
}
