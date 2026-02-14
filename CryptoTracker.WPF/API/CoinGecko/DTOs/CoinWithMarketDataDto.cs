using Newtonsoft.Json;

namespace CryptoTracker.WPF.API.CoinGecko.DTOs
{
    public class CoinWithMarketDataDto
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        [JsonProperty("current_price")]
        public decimal? CurrentPrice { get; set; }
        [JsonProperty("market_cap")]
        public decimal? MarketCap { get; set; }
        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }
        [JsonProperty("fully_diluted_valuation")]
        public decimal? FullyDilutedValuation { get; set; }
        [JsonProperty("total_volume")]
        public decimal? TotalVolume { get; set; }
        [JsonProperty("high_24h")]
        public decimal? High24h { get; set; }
        [JsonProperty("low_24h")]
        public decimal? Low24h { get; set; }
        [JsonProperty("price_change_24h")]
        public decimal? PriceChange24h { get; set; }
        [JsonProperty("price_change_percentage_24h")]
        public double? PriceChangePercentage24h { get; set; }
        [JsonProperty("market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }
        [JsonProperty("market_cap_change_percentage_24h")]
        public double? MarketCapChangePercentage24h { get; set; }
        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }
        [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; }
        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
        [JsonProperty("ath")]
        public decimal? AllTimeHigh { get; set; }
        [JsonProperty("ath_change_percentage")]
        public double? AllTimeHighChangePercentage { get; set; }
        [JsonProperty("ath_date")]
        public DateTimeOffset? AllTimeHighDate { get; set; }
        [JsonProperty("atl")]
        public decimal? AllTimeLow { get; set; }
        [JsonProperty("atl_change_percentage")]
        public double? AllTimeLowChangePercentage { get; set; }
        [JsonProperty("atl_date")]
        public DateTimeOffset? AllTimeLowDate { get; set; }
        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
