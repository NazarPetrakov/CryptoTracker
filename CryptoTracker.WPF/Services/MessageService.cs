using CryptoTracker.WPF.Interfaces;
using System.Windows;

namespace CryptoTracker.WPF.Services
{
    internal class MessageService : IMessageService
    {
        public void ShowError(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption,
                       MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ShowMessage(string message, string caption = "Message")
        {
            MessageBox.Show(message, caption);
        }

    }
}