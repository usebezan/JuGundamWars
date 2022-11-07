using Ju.GundamWars;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Ju.GundamWars.Utilities.DataSaver
{

    class Program
    {

        static void Main(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    CoreHosting.ConfigureServices(context, services);
                    services.AddSingleton<Saver>();
                })
                .Build()
                .Services
                .GetRequiredService<Saver>()
                .Run();

    }

}
