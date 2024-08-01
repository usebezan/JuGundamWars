using Ju.GundamWars.Client;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.CoMobiles.Domain;
using Ju.GundamWars.CoMobiles.View;
using Ju.GundamWars.Cuspas.View;
using Ju.GundamWars.Mobiles.View;
using Ju.GundamWars.Pilots.View;
using Ju.GundamWars.Server;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Supports.View;
using Ju.GundamWars.Systems.Domain;
using Ju.GundamWars.Systems.Presentation;
using Ju.GundamWars.Systems.View;
using Ju.GundamWars.Tags.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;
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
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("SystemSettings.json", false, true);
                    builder.AddJsonFile("MasterUpdateSettings.json", false, true);
                })
                //.ConfigureLogging((context, builder) =>
                //{
                //    builder.ClearProviders();
                //    builder.AddNLog(new NLogLoggingConfiguration(context.Configuration.GetSection("NLog")));
                //})
                .ConfigureClient()
                .ConfigureServer()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<SystemOption>(context.Configuration.GetSection("System"))
                        .PostConfigure<SystemOption>(c =>
                        {
                            c.ExecutingLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";
                        });
                    services.Configure<MasterUpdateOption>(context.Configuration.GetSection("MasterUpdate"));

                    // add DbContext
                    services.AddDbContextFactory<GwMasterDbContext>((provider, options) =>
                    {
#if DEBUG
                        options.EnableSensitiveDataLogging();
#endif
                        var systemOption = provider.GetRequiredService<IOptions<SystemOption>>().Value;
                        // アップデートでファイルを上書きできるように Pooling を False にする
                        options.UseSqlite($@"Filename={systemOption.MasterDbFilePath};Pooling=False");
                    });
                    services.AddDbContextFactory<GwTxnDbContext>((provider, options) =>
                    {
#if DEBUG
                        options.EnableSensitiveDataLogging();
#endif
                        var systemOption = provider.GetRequiredService<IOptions<SystemOption>>().Value;
                        if (!File.Exists(systemOption.TxnDbFilePath))
                        {
                            File.Copy(systemOption.TxnBaseDbFilePath, systemOption.TxnDbFilePath);
                        }
                        options.UseSqlite($@"Filename={systemOption.TxnDbFilePath}");
                    });

                    // Domain
                    services.AddSingleton<CoMobileList>();
                    services.AddSingleton<CoMobileViewState>();
                    // View
                    services.AddSingleton<CoMobileEntryViewModel>();
                    services.AddSingleton<CoMobileListViewModel>();
                    services.AddSingleton<CoMobileViewModel>();

                    services.AddSingleton<CuspaListViewModel>();
                    services.AddSingleton<MobileListViewModel>();
                    services.AddSingleton<PilotListViewModel>();
                    services.AddSingleton<SupportListViewModel>();
                    services.AddSingleton<TagListViewModel>();

                    services.AddSingleton<ILoadAllClientPresenter, LoadAllPresenter>();

                    services.AddSingleton<ProgressViewModel>();

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
