using Ju.GundamWars.BizMaster;
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
        // 汎用ホストの生成（ビルドパターンを使用）
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServerCore()
            .ConfigureClientCore()
            .ConfigureBizMaster()
            .ConfigureClientBizMaster()
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
