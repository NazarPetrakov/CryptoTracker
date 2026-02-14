using CryptoTracker.WPF.Extensions;
using System.Runtime.Serialization;

namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal class CoinByIdParams : BaseQueryParams
    {
        public bool? IncludeLocalization { get; set; }
        public bool? IncludeTickers { get; set; }
        public bool? IncludeMarketData { get; set; }
        public bool? IncludeCommunityData { get; set; }
        public bool? IncludeDeveloperData { get; set; }
        public bool? IncludeSparkline { get; set; }
        public bool? IncludeCategoriesDetails { get; set; }
        public DexPairFormat? DexPairFormat { get; set; }

        public override string ToString()
        {
            Dictionary<string, string?> dict = new Dictionary<string, string?>()
            {
                ["localization"] = IncludeLocalization.ToString(),
                ["tickers"] = IncludeTickers.ToString(),
                ["market_data"] = IncludeMarketData.ToString(),
                ["community_data"] = IncludeCommunityData.ToString(),
                ["developer_data"] = IncludeDeveloperData.ToString(),
                ["sparkline"] = IncludeSparkline.ToString(),
                ["include_categories_details"] = IncludeCategoriesDetails.ToString(),
                ["dex_pair_format"] = DexPairFormat?.ToApiString()
            };

            return ConcatParams(dict);
        }
    }
    internal enum DexPairFormat
    {
        [EnumMember(Value = "symbol")]
        Symbol,
        [EnumMember(Value = "contract_address")]
        ContractAddress
    }
}
