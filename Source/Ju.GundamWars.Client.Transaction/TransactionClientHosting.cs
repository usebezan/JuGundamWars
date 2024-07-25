using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain.Service;
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
                // CoMobiles
                services
                    // Domain
                    .AddSingleton<CoMobileInventory>()
                    // Domain.Service
                    .AddSingleton<CoMobileDtoMapper>()
                    .AddSingleton<CoMobileModelMapper>()
                ;
                // Tags
                services
                    // Domain
                    .AddSingleton<TagInventory>()
                ;
            });
}
