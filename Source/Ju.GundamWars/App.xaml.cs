using Ju.GundamWars.Client;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.CoMobiles.View;
using Ju.GundamWars.Cuspas.View;
using Ju.GundamWars.Mobiles.View;
using Ju.GundamWars.Pilots.View;
using Ju.GundamWars.Server;
using Ju.GundamWars.Supports.View;
using Ju.GundamWars.Systems.Domain;
using Ju.GundamWars.Systems.Presentation;
using Ju.GundamWars.Systems.View;
using Ju.GundamWars.Tags.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;

namespace Ju.GundamWars;

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
        try
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                //.ConfigureAppConfiguration((context, builder) =>
                //{
                //    builder.AddJsonFile("appsettings.json", true, true);
                //})
                //.ConfigureLogging((context, builder) =>
                //{
                //    builder.ClearProviders();
                //    builder.AddNLog(new NLogLoggingConfiguration(context.Configuration.GetSection("NLog")));
                //})
                .ConfigureClient()
                .ConfigureServer()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<CoMobileListViewModel>();
                    services.AddSingleton<CuspaListViewModel>();
                    services.AddSingleton<MobileListViewModel>();
                    services.AddSingleton<PilotListViewModel>();
                    services.AddSingleton<SupportListViewModel>();
                    services.AddSingleton<TagListViewModel>();

                    services.AddSingleton<ILoadAllClientPresenter, LoadAllPresenter>();
                    services.AddSingleton<LoadAllProgressViewModel>();

                    services.AddSingleton<Menus>();
                    services.AddSingleton<ViewState>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();
                }).Build();
        }
        catch (Exception ex)
        {
            File.WriteAllText("App.log", ex.ToString());
        }
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
