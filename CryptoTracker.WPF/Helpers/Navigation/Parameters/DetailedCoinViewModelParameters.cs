using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.Helpers.Navigation.Parameters
{
    internal class DetailedCoinViewModelParameters : IViewModelParameters
    {
        public string Id { get; init; }

        public DetailedCoinViewModelParameters(string id)
        {
            Id = id;
        }
    }
}
