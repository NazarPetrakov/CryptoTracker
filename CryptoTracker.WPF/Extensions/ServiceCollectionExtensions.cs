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

            return services;
        }
    }
}
