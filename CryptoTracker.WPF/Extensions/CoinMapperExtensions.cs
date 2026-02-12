using CryptoTracker.WPF.API.CoinGecko.DTOs;
using CryptoTracker.WPF.Models;

namespace CryptoTracker.WPF.Extensions
{
    internal static class CoinMapperExtensions
    {
        public static Coin ToModel(this CoinWithMarketDataDto coinDto)
        {
            return new Coin(
                coinDto.Id ?? "Unknown id",
                coinDto.Symbol ?? "Unknown symbol",
                coinDto.Name ?? "Unknown name",
                coinDto.CurrentPrice ?? 0,
                coinDto.Image ?? "");
        }
    }
}
