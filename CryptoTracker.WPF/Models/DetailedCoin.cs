using CryptoTracker.WPF.API.CoinGecko.DTOs;

namespace CryptoTracker.WPF.Models
{
    internal class DetailedCoin
    {
        public string Id { get; init; }
        public string Symbol { get; init; }
        public string Name { get; init; }
        public ImageDto Image { get; init; }
        public int MarketCapRank { get; set; }
        public MarketDataDto MarketData { get; set; }
        public string Description { get; set; }
        public TickerDto[] Tickers { get; set; }

        public DetailedCoin(string id, string symbol, string name, ImageDto image, int marketCapRank, MarketDataDto marketData, string description, TickerDto[] tickers)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            Image = image;
            MarketCapRank = marketCapRank;
            MarketData = marketData;
            Description = description;
            Tickers = tickers;
        }
    }
}
