namespace CryptoTracker.WPF.Interfaces
{
    public interface ICoinHttpClient
    {
        Task<T?> GetAsync<T>(string uri);
    }
}
