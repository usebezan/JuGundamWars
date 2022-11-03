using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Ju.GundamWars.ViewModels;
using Ju.GundamWars.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;


namespace Ju.GundamWars
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost Host { get; private set; } = null!;


        public static T GetRequiredService<T>()
            where T : notnull
        {
            return Host.Services.GetRequiredService<T>();
        }


        public App()
        {
            Host = new HostBuilder().ConfigureServices(ConfigureServices).Build();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            // add services:
            CoreHosting.ConfigureServices(context, services);

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("AppSettings.json", false)
                .Build();

            // add config
            services.Configure<UserSetting>(configuration.GetSection(nameof(UserSetting)));

            // add services:
            services.AddSingleton<MiscRepository>();

            services.AddSingleton<WindowService>();

            services.AddSingleton<MessageDialogViewModel>();
            services.AddSingleton<YesNoDialog>();

            services.AddSingleton<MobileSuitModelRepository>();
            services.AddSingleton<MobileSuitFilterViewModel>();
            services.AddSingleton<MobileSuitListViewModel>();

            services.AddSingleton<PilotModelRepository>();
            services.AddSingleton<PilotFilterViewModel>();
            services.AddSingleton<PilotListViewModel>();

            services.AddSingleton<SupportModelRepository>();
            services.AddSingleton<SupportFilterViewModel>();
            services.AddSingleton<SupportListViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await Host.StartAsync();
            var window = GetRequiredService<MainWindow>();
            window.Show();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            using (Host)
            {
                await Host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }

    }

}
