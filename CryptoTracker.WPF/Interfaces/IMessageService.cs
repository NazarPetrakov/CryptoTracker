namespace CryptoTracker.WPF.Interfaces
{
    internal interface IMessageService
    {
        void ShowError(string message, string caption = "Error");
        void ShowMessage(string message, string caption = "Message");
    }
}
