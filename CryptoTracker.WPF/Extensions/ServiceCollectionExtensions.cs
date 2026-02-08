using CommunityToolkit.Mvvm.ComponentModel;
using CryptoTracker.WPF.Interfaces;
using CryptoTracker.WPF.Services;
using CryptoTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTracker.WPF.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ObservableObject>>(provider =>
                viewModelType => (ObservableObject)provider.GetRequiredService(viewModelType));

            return services;
        }
    }
}
