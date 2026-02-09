namespace CryptoTracker.WPF.Models
{
    public class Coin
    {
        public string Id { get; init; }
        public string Symbol { get; init; }
        public string Name { get; init; }

        public Coin(string id, string symbol, string name)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
        }
    }
}
