namespace CryptoTracker.WPF.Interfaces
{
    internal interface ICoinHttpClient
    {
        Task<T?> GetAsync<T>(string uri);
    }
}
