namespace CryptoTracker.WPF.Helpers.Errors
{
    internal sealed record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
