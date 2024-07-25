using ConsoleApp1.Presentation;
using Ju.GundamWars.Client;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureClient()
            .ConfigureServer()
            .ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders().AddConsole();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<Runner>();
                services.AddSingleton<ILoadAllClientPresenter, LoadAllClientPresenter>();
                services.AddSingleton<IUpdatePresenter<Tag>, UpdateTagPresenter>();
                services.AddSingleton<IDeletePresenter<CoMobile>, DeleteCoMobilePresenter>();
                services.AddSingleton<IInsertPresenter<CoMobile>, InsertCoMobilePresenter>();
                services.AddSingleton<IUpdatePresenter<CoMobile>, UpdateCoMobilePresenter>();
            })
            .Build();
        try
        {
            host.Services.GetRequiredService<Runner>().RunAsync().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
