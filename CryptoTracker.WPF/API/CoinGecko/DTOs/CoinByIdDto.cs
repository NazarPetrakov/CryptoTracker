using Newtonsoft.Json;

namespace CryptoTracker.WPF.API.CoinGecko.DTOs
{
    internal class CoinByIdDto
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public Dictionary<string, string> Localization { get; set; } = [];
        public Dictionary<string, string> Description { get; set; } = [];
        public LinksContainer? Links { get; set; }
        public ImageDto? Image { get; set; }
        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }
        [JsonProperty("market_data")]
        public MarketDataDto? MarketData { get; set; }
        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
        [JsonProperty("tickers")]
        public TickerDto[]? Tickers { get; set; } = [];
    }
    internal record PriceInCurrency(decimal? Btc, decimal? Eur, decimal? Usd, decimal? Uah);
    internal record DateByCurrency(DateTimeOffset? Btc, DateTimeOffset? Eur, DateTimeOffset? Usd, DateTimeOffset? Uah);
    internal record LinksContainer(string[] Homepage);
    internal record ImageDto(string Thumb, string Small, string Large);
    internal record MarketDto(string? Name, string? Identifier);
    internal class TickerDto
    {
        public string? Base { get; set; }
        public string? Target { get; set; }
        public MarketDto? Market { get; set; }
        [JsonProperty("converted_last")]
        public PriceInCurrency? ConvertedLast { get; set; }
        [JsonProperty("converted_volume")]
        public PriceInCurrency? ConvertedVolume { get; set; }
        [JsonProperty("trade_url")]
        public string? TradeUrl { get; set; }
        [JsonProperty("bid_ask_spread_percentage")]
        public decimal? BidAskSpreadPercentage { get; set; }

    }
    internal class MarketDataDto
    {
        [JsonProperty("current_price")]
        public PriceInCurrency? CurrentPrice { get; set; }
        [JsonProperty("ath")]
        public PriceInCurrency? AllTimeHigh { get; set; }
        [JsonProperty("ath_change_percentage")]
        public PriceInCurrency? AllTimeHighChangePercentage { get; set; }
        [JsonProperty("ath_date")]
        public DateByCurrency? AllTimeHighDate { get; set; }
        [JsonProperty("atl")]
        public PriceInCurrency? AllTimeLow { get; set; }
        [JsonProperty("atl_change_percentage")]
        public PriceInCurrency? AllTimeLowChangePercentage { get; set; }
        [JsonProperty("atl_date")]
        public DateByCurrency? AllTimeLowDate { get; set; }
        [JsonProperty("market_cap")]
        public PriceInCurrency? MarketCap { get; set; }
        [JsonProperty("fully_diluted_valuation")]
        public PriceInCurrency? FullyDilutedValuation { get; set; }
        [JsonProperty("market_cap_fdv_ratio")]
        public decimal? MarketCupToFdvRatio { get; set; }
        [JsonProperty("total_volume")]
        public PriceInCurrency? TotalVolume { get; set; }
        [JsonProperty("high_24h")]
        public PriceInCurrency? High24h { get; set; }
        [JsonProperty("low_24h")]
        public PriceInCurrency? Low24h { get; set; }
        [JsonProperty("price_change_24h_in_currency")]
        public PriceInCurrency? PriceChange24h { get; set; }
        [JsonProperty("price_change_percentage_1h_in_currency")]
        public PriceInCurrency? PriceChangePercentage1h { get; set; }
        [JsonProperty("price_change_percentage_24h_in_currency")]
        public PriceInCurrency? PriceChangePercentage24h { get; set; }
        [JsonProperty("price_change_percentage_7d_in_currency")]
        public PriceInCurrency? PriceChangePercentage7d { get; set; }
        [JsonProperty("price_change_percentage_14d_in_currency")]
        public PriceInCurrency? PriceChangePercentage14d { get; set; }
        [JsonProperty("price_change_percentage_30d_in_currency")]
        public PriceInCurrency? PriceChangePercentage30d { get; set; }
        [JsonProperty("price_change_percentage_60d_in_currency")]
        public PriceInCurrency? PriceChangePercentage60d { get; set; }
        [JsonProperty("price_change_percentage_200d_in_currency")]
        public PriceInCurrency? PriceChangePercentage200d { get; set; }
        [JsonProperty("price_change_percentage_1y_in_currency")]
        public PriceInCurrency? PriceChangePercentage1y { get; set; }
        [JsonProperty("market_cap_change_24h_in_currency")]
        public PriceInCurrency? MarketCapChange24h { get; set; }
        [JsonProperty("market_cap_change_percentage_24h_in_currency")]
        public PriceInCurrency? MarketCapChangePercentage24h { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }
        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
