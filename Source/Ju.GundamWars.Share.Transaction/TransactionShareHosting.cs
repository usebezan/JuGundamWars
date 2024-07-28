using Ju.GundamWars.Share.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.Cuspas.Domain.Service;
using Ju.GundamWars.Share.Pilots.Domain.Service;
using Ju.GundamWars.Share.Supports.Domain.Service;
using Ju.GundamWars.Share.Tags.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Share;

public static class TransactionShareHosting
{
    public static IHostBuilder ConfigureTransactionShare(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // CoMobiles
                services
                    // Domain.Service
                    .AddSingleton(typeof(CoMobileSanitizer<>))
                ;

                // Cuspas
                services
                    // Domain.Service
                    .AddSingleton(typeof(CuspaSanitizer<>))
                ;

                // Pilots
                services
                    // Domain.Service
                    .AddSingleton(typeof(PilotSanitizer<>))
                ;

                // Supports
                services
                    // Domain.Service
                    .AddSingleton(typeof(SupportSanitizer<>))
                ;

                // Tags
                services
                    // Domain.Service
                    .AddSingleton(typeof(TagMapper<,>))
                    .AddSingleton(typeof(UpdateTagSanitizer<>))
                ;
            });
}
