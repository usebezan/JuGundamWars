using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain.Service;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Cuspas.Domain.Service;
using Ju.GundamWars.Client.Cuspas.Infrastructure.WebClient;
using Ju.GundamWars.Client.Pilots.Domain.Service;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.Pilots.Infrastructure.WebClient;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
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
                    // Infrastructure.WebClient
                    .AddSingleton<CoMobileWebClient>()
                ;

                // Cuspas
                services
                    // Domain
                    .AddSingleton<CuspaInventory>()
                    // Domain.Service
                    .AddSingleton<CuspaDtoMapper>()
                    .AddSingleton<CuspaModelMapper>()
                    // Infrastructure.WebClient
                    .AddSingleton<CuspaWebClient>()
                ;

                // Pilots
                services
                    // Domain
                    .AddSingleton<PilotInventory>()
                    // Domain.Service
                    .AddSingleton<PilotDtoMapper>()
                    .AddSingleton<PilotModelMapper>()
                    // Infrastructure.WebClient
                    .AddSingleton<PilotWebClient>()
                ;

                // Tags
                services
                    // Domain
                    .AddSingleton<TagInventory>()
                    // Infrastructure.WebClient
                    .AddSingleton<TagWebClient>()
                ;
            });
}
