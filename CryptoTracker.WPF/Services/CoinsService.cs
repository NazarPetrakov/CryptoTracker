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
        public async Task<CoinByIdDto> GetCoinByIdAsync(string coinId, CoinByIdParams? queryParams)
        {
            var endpoint = AddQueryParameters($"coins/{coinId}", queryParams);

            var coin = await _httpClient.GetAsync<CoinByIdDto>(endpoint);

            return coin!;
        }
        public async Task<IEnumerable<CoinWithMarketDataDto>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null)
        {
            var endpoint = AddQueryParameters("coins/markets", queryParams);

            var coins = await _httpClient.GetAsync<IEnumerable<CoinWithMarketDataDto>>(endpoint);

            return coins!;
        }
        private string AddQueryParameters(string endpoint, BaseQueryParams? queryParams)
        {
            if (queryParams is not null)
            {
                var queryParamsString = queryParams.ToString();
                endpoint += "?" + queryParamsString;
            }
            return endpoint;
        }
    }
}
