using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.Errors;
using CryptoTracker.WPF.Helpers.QueryParameters;
using CryptoTracker.WPF.Helpers.ResultT;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Models;

namespace CryptoTracker.WPF.Services
{
    internal class CoinsService : ICoinsService
    {
        private readonly ICoinHttpClient _httpClient;
        public CoinsService(ICoinHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultT<DetailedCoin>> GetCoinByIdAsync(
            string coinId, CoinByIdParams? queryParams)
        {
            var endpoint = AddQueryParameters($"coins/{coinId}", queryParams);

            var coinDtoResult = await _httpClient.GetAsync<CoinByIdDto>(endpoint);

            if (!coinDtoResult.IsSuccess)
                return ResultT<DetailedCoin>.Failure(coinDtoResult.Error!);

            return ResultT<DetailedCoin>.Success(coinDtoResult.Value.ToModel());
        }
        public async Task<ResultT<IEnumerable<Coin>>> GetCoinsWithMarketDataAsync(
            CoinWithMarketDataParams? queryParams = null)
        {
            var endpoint = AddQueryParameters("coins/markets", queryParams);

            var coinsDtoResult = await _httpClient.GetAsync<IEnumerable<CoinWithMarketDataDto>>(endpoint);

            if (!coinsDtoResult.IsSuccess)
                return ResultT<IEnumerable<Coin>>.Failure(coinsDtoResult.Error!);

            return ResultT<IEnumerable<Coin>>.Success(coinsDtoResult.Value.Select(dto => dto.ToModel()));
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
