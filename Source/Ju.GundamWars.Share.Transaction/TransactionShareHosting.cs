using Ju.GundamWars.Share.Tags.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Share;

public static class TransactionShareHosting
{
    public static IHostBuilder ConfigureBizTxn(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Tags
                services
                    // Domain
                    .AddSingleton(typeof(TagPrimitiveMapper<,>))
                ;
            });
}
