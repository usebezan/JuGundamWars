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
                    // Domain
                    .AddSingleton(typeof(CoMobileMapper<,,,>))
                    .AddSingleton(typeof(CoMobileTagMapMapper<,>))
                    .AddSingleton(typeof(InsertCoMobileSanitizer<>))
                    .AddSingleton(typeof(UpdateCoMobileSanitizer<>))
                ;
                // Tags
                services
                    // Domain
                    .AddSingleton(typeof(TagMapper<,>))
                    .AddSingleton(typeof(UpdateTagSanitizer<>))
                ;
            });
}
