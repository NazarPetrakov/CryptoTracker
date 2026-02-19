namespace CryptoTracker.WPF.Helpers.Errors
{
    internal static class CoinGeckoErrors
    {
        public static Error EmptyResponse =>
            new("CoinGecko.EmptyResponse", "The server returned empty or invalid response");
        public static Error ApiError(int statuCode, string statusCodeName, string message) =>
            new($"{statuCode} {statusCodeName}", message);
        public static Error MissingData(string coin, string currency) =>
            new("CoinGecko.MissingData", $"Data for '{coin}' in '{currency}' was not found in the response.");
    }
}
