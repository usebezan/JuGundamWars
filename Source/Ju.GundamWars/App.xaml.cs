using Ju.GundamWars.Application;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;
using Ju.GundamWars.Persistence;
using Ju.GundamWars.Persistence2;
using Ju.GundamWars.Pilots;
using Ju.GundamWars.Supports;
using Ju.GundamWars.Systems;
using Ju.GundamWars.Tags;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using static Microsoft.Extensions.Hosting.Host;

namespace Ju.GundamWars;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
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
            Host = CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", true, true);
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.ClearProviders();
                    builder.AddNLog(new NLogLoggingConfiguration(context.Configuration.GetSection("NLog")));
                })
                .ConfigureApplicationServices()
                .ConfigurePersistenceServices()
                .ConfigurePersistence2Services()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<SystemOption>(context.Configuration.GetSection("System"))
                        .PostConfigure<SystemOption>(c =>
                        {
                            c.MasterDbFilePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "."}\Data\JuGundamWarsMaster.db";
                        });

                    services.AddInventory<IBoostInventory, BoostInventory>();
                    services.AddInventory<ICategoryInventory, CategoryInventory>();
                    services.AddInventory<ICuspaKindInventory, CuspaKindInventory>();
                    services.AddInventory<IGradeInventory, GradeInventory>();
                    services.AddInventory<IHasAceInventory, HasAceInventory>();
                    services.AddInventory<IMobileKindInventory, MobileKindInventory>();
                    services.AddInventory<IPositionInventory, PositionInventory>();
                    services.AddInventory<IRoleInventory, RoleInventory>();
                    services.AddInventory<ITerrainInventory, TerrainInventory>();

                    services.AddInventory<IMobileSSkillInventory, MobileSSkillInventory>();
                    services.AddInventory<IPilotAbilityInventory, PilotAbilityInventory>();
                    services.AddInventory<IPilotSkillInventory, PilotSkillInventory>();
                    services.AddInventory<ISerialInventory, SerialInventory>();
                    services.AddInventory<ISupportBadgeInventory, SupportBadgeInventory>();
                    services.AddInventory<ISupportSlotInventory, SupportSlotInventory>();

                    services.AddInventory<ICoMobileInventory, CoMobileInventory>();
                    services.AddSingleton<CoMobileEntryController>();
                    services.AddSingleton<CoMobileEntryViewModel>();
                    services.AddSingleton<CoMobileListController>();
                    services.AddSingleton<CoMobileListViewModel>();
                    services.AddSingleton<CoMobileSelectionController>();
                    services.AddSingleton<CoMobileSelectionViewModel>();

                    services.AddInventory<ICuspaInventory, CuspaInventory>();
                    services.AddSingleton<CuspaEntryController>();
                    services.AddSingleton<CuspaEntryViewModel>();
                    services.AddSingleton<CuspaListController>();
                    services.AddSingleton<CuspaListViewModel>();
                    services.AddSingleton<NCuspaSelectionController>();
                    services.AddSingleton<NCuspaSelectionViewModel>();
                    services.AddSingleton<SCuspaSelectionController>();
                    services.AddSingleton<SCuspaSelectionViewModel>();

                    services.AddInventory<IMobileInventory, MobileInventory>();
                    services.AddSingleton<MobileEntryController>();
                    services.AddSingleton<MobileEntryViewModel>();
                    services.AddSingleton<MobileListController>();
                    services.AddSingleton<MobileListViewModel>();
                    services.AddSingleton<MobileSelectionController>();
                    services.AddSingleton<MobileSelectionViewModel>();

                    services.AddInventory<IPilotInventory, PilotInventory>();
                    services.AddSingleton<PilotEntryController>();
                    services.AddSingleton<PilotEntryViewModel>();
                    services.AddSingleton<PilotListController>();
                    services.AddSingleton<PilotListViewModel>();
                    services.AddSingleton<PilotSelectionController>();
                    services.AddSingleton<PilotSelectionViewModel>();

                    services.AddInventory<ISupportInventory, SupportInventory>();
                    services.AddSingleton<SupportEntryController>();
                    services.AddSingleton<SupportEntryViewModel>();
                    services.AddSingleton<SupportListController>();
                    services.AddSingleton<SupportListViewModel>();
                    services.AddSingleton<SupportSelectionController>();
                    services.AddSingleton<SupportSelectionViewModel>();

                    services.AddInventory<ITagInventory, TagInventory>();
                    services.AddSingleton<TagListController>();
                    services.AddSingleton<TagListViewModel>();

                    services.AddSingleton<ISnackbarPresenter, Snackbar>();

                    services.AddSingleton<IDialogPresenter, Dialog>();
                    services.AddSingleton<AskDialogViewModel>();

                    services.AddSingleton<IProgressPresenter, Progress>();
                    services.AddSingleton<ProgressViewModel>();

                    services.AddSingleton<IEnterPresenter, EnterPresenter>();

                    services.AddSingleton<MainController>();
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
