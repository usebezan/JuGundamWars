using Ju.GundamWars.Client.AceImpls.Domain;
using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Grades.Domain;
using Ju.GundamWars.Client.MobileKinds.Domain;
using Ju.GundamWars.Client.Positions.Domain;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Terrains.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class ConstClientHosting
{
    public static IHostBuilder ConfigureConstClient(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // AceImpls
                services
                    // Domain
                    .AddSingleton<AceImplInventory>()
                ;
                // Boosts
                services
                    // Domain
                    .AddSingleton<BoostStatusInventory>()
                ;
                // CuspaKinds
                services
                    // Domain
                    .AddSingleton<CuspaKindInventory>()
                ;
                // Grades
                services
                    // Domain
                    .AddSingleton<GradeInventory>()
                ;
                // MobileKinds
                services
                    // Domain
                    .AddSingleton<MobileKindInventory>()
                ;
                // Positions
                services
                    // Domain
                    .AddSingleton<PositionInventory>()
                ;
                // Roles
                services
                    // Domain
                    .AddSingleton<RoleInventory>()
                ;
                // Terrains
                services
                    // Domain
                    .AddSingleton<TerrainInventory>()
                ;
            });
}
