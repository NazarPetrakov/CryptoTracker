namespace CryptoTracker.WPF.Models
{
    public class Currency
    {
        public string Name { get; }
        public string Code { get; }

        public Currency(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
