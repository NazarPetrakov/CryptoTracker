using System.Runtime.Serialization;

namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    public class CoinWithMarketDataParams : PaginationQueryParameters
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

    }
    public enum Locale
    {
        [EnumMember(Value = "en")]
        En,
        [EnumMember(Value = "uk")]
        Uk
    }
    public enum IncludeTokens
    {

        [EnumMember(Value = "top")]
        Top,
        [EnumMember(Value = "all")]
        All
    }
    public enum CoinsOrderBy
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
