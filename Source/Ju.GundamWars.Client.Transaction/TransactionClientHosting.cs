using Ju.GundamWars.Client.Tags.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class TransactionClientHosting
{
    public static IHostBuilder ConfigureTransactionClient(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Tags
                services
                    // Domain
                    .AddSingleton<TagInventory>()
                ;
            });
}
