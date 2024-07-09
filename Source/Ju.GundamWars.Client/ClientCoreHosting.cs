using Ju.GundamWars.Client.Commons;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class ClientCoreHosting
{
    public static IHostBuilder ConfigureClientCore(this IHostBuilder self) =>
        self
            .ConfigureCommonsClientCore();
}
