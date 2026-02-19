using CryptoTracker.WPF.Helpers.ResultT;

namespace CryptoTracker.WPF.Interfaces
{
    internal interface ICoinHttpClient
    {
        Task<ResultT<T>> GetAsync<T>(string uri);
    }
}
