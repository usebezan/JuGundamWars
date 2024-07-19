using Ju.GundamWars.Server.Tags.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Server;

public static class TransactionServerHosting
{
    public static IHostBuilder ConfigureTransactionServer(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Tags
                services
                    // Domain
                    .AddSingleton<UpdateTagSanitizer>()
                ;
            });
}

//.AddSingleton<ITxnRepository<CoMobileDto>, CoMobileRepository>()
//.AddSingleton<ITxnRepository<CuspaDto>, CuspaRepository>()
//.AddSingleton<ITxnRepository<PilotDto>, PilotRepository>()
//.AddSingleton<ITxnRepository<SupportDto>, SupportRepository>()
