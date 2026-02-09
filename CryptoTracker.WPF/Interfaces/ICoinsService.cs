using CryptoTracker.WPF.Models;

namespace CryptoTracker.WPF.Interfaces
{
    public interface ICoinsService
    {
        Task<List<Coin>> GetCoinsList();
    }
}
