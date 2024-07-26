using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Server;

public static class MasterServerHosting
{
    public static IHostBuilder ConfigureMasterServer(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Commons
                services
                    // Infrastructure.WebApi
                    .AddSingleton(typeof(MasterController<,,>))
                ;
            });
}
