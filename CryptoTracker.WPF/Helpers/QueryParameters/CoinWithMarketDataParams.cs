using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.Helpers.QueryParameters.Enums;
using System.Runtime.Serialization;

namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal class CoinWithMarketDataParams : PaginationQueryParams
    {
        public string VsCurrency { get; set; } = "usd";
        public string? Ids { get; set; }
        public string? Names { get; set; }
        public string? Symbols { get; set; }
        public IncludeTokens? IncludeTokens { get; set; }
        public CoinsOrderBy? Order { get; set; }
        public bool? Sparkline { get; set; }
        public Locale? Locale { get; set; }
        public string? Precision { get; set; }

        public override string ToString()
        {
            Dictionary<string, string?> dict = new Dictionary<string, string?>()
            {
                ["vs_currency"] = VsCurrency,
                ["ids"] = Ids,
                ["names"] = Names,
                ["symbols"] = Symbols,
                ["include_tokens"] = IncludeTokens?.ToApiString(),
                ["order"] = Order?.ToApiString(),
                ["per_page"] = PerPage?.ToString(),
                ["page"] = Page?.ToString(),
                ["sparkline"] = Sparkline?.ToString().ToLower(),
                ["precision"] = Precision,
                ["locale"] = Locale.ToApiString(),
            }; ;

            return ConcatParams(dict);
        }
    }
    internal enum Locale
    {
        [EnumMember(Value = "en")]
        En,
        [EnumMember(Value = "uk")]
        Uk
    }
    internal enum CoinsOrderBy
    {
        [EnumMember(Value = "market_cap_asc")]
        MarketCapAsc,
        [EnumMember(Value = "market_cap_desc")]
        MarketCapDesc,
        [EnumMember(Value = "volume_asc")]
        VolumeAsc,
        [EnumMember(Value = "volume_desc")]
        VolumeDesc,
        [EnumMember(Value = "id_asc")]
        IdAsc,
        [EnumMember(Value = "id_desc")]
        IdDesc
    }
}
