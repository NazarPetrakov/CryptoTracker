using CryptoTracker.WPF.Extensions;
using CryptoTracker.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CryptoTracker.WPF
{
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddAppOptions(context.Configuration).AddServices();
                })
                .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainViewModel mainViewModel = _host.Services
                .GetRequiredService<MainViewModel>();

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync().GetAwaiter().GetResult();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
