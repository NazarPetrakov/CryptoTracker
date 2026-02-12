using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Helpers.QueryParameters;
using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.Services
{
    internal class CoinsService : ICoinsService
    {
        private readonly ICoinHttpClient _httpClient;
        public CoinsService(ICoinHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CoinWithMarketDataDto>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null)
        {
            string uri = "coins/markets";

            if (queryParams is not null)
            {
                var queryParamsString = QueryParamsBuilder.ToQueryString(queryParams);
                uri += "?" + queryParamsString;
            }

            var coins = await _httpClient.GetAsync<IEnumerable<CoinWithMarketDataDto>>(uri);

            return coins!;
        }
    }
}
