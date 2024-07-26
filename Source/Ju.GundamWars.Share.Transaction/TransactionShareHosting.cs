using Ju.GundamWars.Share.CoMobiles.Domain.Service;
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
                // Tags
                services
                    // Domain.Service
                    .AddSingleton(typeof(TagMapper<,>))
                    .AddSingleton(typeof(UpdateTagSanitizer<>))
                ;
            });
}
