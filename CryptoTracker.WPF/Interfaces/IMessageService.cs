namespace CryptoTracker.WPF.Interfaces
{
    public interface IMessageService
    {
        void ShowError(string message);
        void ShowMessage(string message, string caption = "Message");
    }
}
