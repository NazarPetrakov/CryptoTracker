using CryptoTracker.WPF.Interfaces;
using System.Windows;

namespace CryptoTracker.WPF.Services
{
    internal class ThemeService : IThemeService
    {
        public void SetTheme(bool isDark)
        {
            var newThemeSource = isDark
                ? new Uri("Resources/Styles/Themes/DarkTheme.xaml", UriKind.Relative)
                : new Uri("Resources/Styles/Themes/LightTheme.xaml", UriKind.Relative);

            var existingTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d =>
                d.Source != null &&
                (d.Source.OriginalString.Contains("DarkTheme.xaml") ||
                 d.Source.OriginalString.Contains("LightTheme.xaml")));

            if (existingTheme != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(existingTheme);
            }

            Application.Current.Resources.MergedDictionaries
                .Insert(0, new ResourceDictionary { Source = newThemeSource });
        }
    }
}
