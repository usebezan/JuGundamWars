using Ju.GundamWars.BizTxn.Tags.Domain.Inventory;
using Ju.GundamWars.BizTxn.Tags.Domain.Service.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.BizTxn;

public static class BizTxnHosting
{
    // Server、Client 両方で使用
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
    // Client で使用
    public static IHostBuilder ConfigureClientBizTxn(this IHostBuilder self) =>
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
