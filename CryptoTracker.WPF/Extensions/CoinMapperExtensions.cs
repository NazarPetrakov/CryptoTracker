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
        public static DetailedCoin ToModel(this CoinByIdDto coinByIdDto)
        {
            return new DetailedCoin(
                coinByIdDto.Id ?? "Unknown id",
                coinByIdDto.Symbol ?? "Unknown symbol",
                coinByIdDto.Name ?? "Unknown name",
                coinByIdDto.Image ?? new ImageDto("", "", ""),
                coinByIdDto.MarketCapRank ?? 0,
                coinByIdDto.MarketData ?? new MarketDataDto(),
                coinByIdDto.Description["en"],
                coinByIdDto.Tickers ?? []);
        }
    }
}
