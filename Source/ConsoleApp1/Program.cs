using Ju.GundamWars.BizConst;
using Ju.GundamWars.BizMaster;
using Ju.GundamWars.BizTxn;
using Ju.GundamWars.Client;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
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
            .ConfigureServerCore()
            .ConfigureClientCore()
            .ConfigureClientBizConst()
            .ConfigureBizMaster()
            .ConfigureClientBizMaster()
            .ConfigureBizTxn()
            .ConfigureClientBizTxn()
            .ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders().AddConsole();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<Runner>();
                services.AddSingleton<ILoadAllClientPresenter, LoadAllClientPresenter>();
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
