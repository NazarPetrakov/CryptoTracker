using CryptoTracker.WPF.Extensions;

namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal static class QueryParamsBuilder
    {
        public static string ToQueryString(CoinWithMarketDataParams q)
        {
            var dict = new Dictionary<string, string?>()
            {
                ["vs_currency"] = q.VsCurrency,
                ["ids"] = q.Ids,
                ["names"] = q.Names,
                ["symbols"] = q.Symbols,
                ["include_tokens"] = q.IncludeTokens?.ToApiString(),
                ["order"] = q.Order?.ToApiString(),
                ["per_page"] = q.PerPage?.ToString(),
                ["page"] = q.Page?.ToString(),
                ["sparkline"] = q.Sparkline?.ToString().ToLower(),
                ["precision"] = q.Precision
            };

            return string.Join("&",
                dict.Where(x => x.Value is not null)
                    .Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value!)}"));
        }
    }
}
