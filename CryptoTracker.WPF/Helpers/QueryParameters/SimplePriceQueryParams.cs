using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.QueryParameters.Enums;

namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal class SimplePriceQueryParams : BaseQueryParams
    {
        public string VsCurrency { get; set; } = "usd";
        public string? Ids { get; set; }
        public string? Names { get; set; }
        public string? Symbols { get; set; }
        public IncludeTokens? IncludeTokens { get; set; }
        public bool? IncludeMarketCap { get; set; }
        public bool? Include24HourVolume { get; set; }
        public bool? Include24HourChange { get; set; }
        public bool? IncludeLastUpdatedAt { get; set; }
        public string? Precision { get; set; }

        public override string ToString()
        {
            Dictionary<string, string?> dict = new Dictionary<string, string?>()
            {
                ["vs_currencies"] = VsCurrency,
                ["ids"] = Ids,
                ["names"] = Names,
                ["symbols"] = Symbols,
                ["include_tokens"] = IncludeTokens?.ToApiString(),
                ["include_market_cap"] = IncludeMarketCap?.ToString(),
                ["include_24hr_vol"] = Include24HourVolume?.ToString(),
                ["include_24hr_change"] = Include24HourChange?.ToString(),
                ["include_last_updated_at"] = IncludeLastUpdatedAt?.ToString(),
                ["precision"] = Precision,
            };

            return ConcatParams(dict);
        }
    }
}
