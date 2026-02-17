using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoTracker.WPF.Interfaces;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        private readonly IThemeService _themeService;
        [ObservableProperty]
        private bool _isDarkMode = true;

        public SettingsViewModel(IThemeService themeService)
        {
            _themeService = themeService;
        }
        [RelayCommand]
        private void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            _themeService.SetTheme(IsDarkMode);
        }
    }
}
