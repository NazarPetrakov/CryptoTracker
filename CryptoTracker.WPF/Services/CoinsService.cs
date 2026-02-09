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
        public async Task<List<Coin>> GetCoinsList()
        {
            var coins = await _httpClient.GetAsync<List<Coin>>("coins/list");

            return coins;
        }
    }
}
