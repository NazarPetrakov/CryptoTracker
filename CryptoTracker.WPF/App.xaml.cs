using CryptoTracker.WPF.Extensions;
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
                .ConfigureServices(services => services.AddServices())
                .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
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
