namespace CryptoTracker.WPF.Interfaces
{
    internal interface IMessageService
    {
        void ShowError(string message);
        void ShowMessage(string message, string caption = "Message");
    }
}
