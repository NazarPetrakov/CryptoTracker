namespace CryptoTracker.WPF.Models
{
    public class Coin
    {
        public string Id { get; init; }
        public string Symbol { get; init; }
        public string Name { get; init; }
        public decimal CurrentPrice { get; init; }
        public string Image { get; init; }

        public Coin(string id, string symbol, string name, decimal price, string image)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            CurrentPrice = price;
            Image = image;

        }
    }
}
