namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal abstract class BaseQueryParams
    {
        public abstract override string ToString();

        public static string ConcatParams(Dictionary<string, string?> dict)
        {
            return string.Join("&",
                dict.Where(x => x.Value is not null)
                    .Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value!)}"));
        }

    }
}
