using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.API.CoinGecko;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Options;
using CryptoTracker.WPF.Services;
using CryptoTracker.WPF.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTracker.WPF.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<DetailedCoinViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddTransient<PaginationViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ICoinsService, CoinsService>();
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IThemeService, ThemeService>();

            services.AddSingleton<Func<Type, ObservableObject>>(provider =>
                viewModelType => (ObservableObject)provider.GetRequiredService(viewModelType));

            services.AddHttpClient<ICoinHttpClient, CoinGeckoHttpClient>();

            return services;
        }
        internal static IServiceCollection AddAppOptions(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CoinGeckoOptions>(configuration.GetSection(nameof(CoinGeckoOptions)));

            return services;
        }
    }
}

