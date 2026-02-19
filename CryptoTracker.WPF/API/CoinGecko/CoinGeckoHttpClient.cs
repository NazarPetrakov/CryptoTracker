using CryptoTracker.WPF.Helpers.Errors;
using CryptoTracker.WPF.Helpers.ResultT;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace CryptoTracker.WPF.API.CoinGecko
{
    internal class CoinGeckoHttpClient : ICoinHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY_HEADER_NAME = "x-cg-demo-api-key";

        public CoinGeckoHttpClient(HttpClient httpClient, IOptions<CoinGeckoOptions> coinGeckoOptions)
        {
            var options = coinGeckoOptions.Value;
            var productInfo = Assembly
                .GetExecutingAssembly()
                .GetName();

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.BaseAddress);
            _httpClient.DefaultRequestHeaders.Add(API_KEY_HEADER_NAME, options.ApiKey);

            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent
                .Add(new ProductInfoHeaderValue(
                    productInfo.Name ?? "CryptoTracker",
                    productInfo.Version?.ToString() ?? "1.0"));
        }

        public async Task<ResultT<T>> GetAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                return CoinGeckoErrors.ApiError(
                    (int)response.StatusCode, response.StatusCode.ToString(), body);
            }

            var content = await response.Content.ReadAsStringAsync();

            var objectToReturn = JsonConvert.DeserializeObject<T>(content);

            if (objectToReturn is null)
                return CoinGeckoErrors.EmptyResponse;

            return objectToReturn;
        }
    }
}
