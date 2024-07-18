using Ju.GundamWars.BizConst.AceImpls.Domain;
using Ju.GundamWars.BizConst.CuspaKinds.Domain;
using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizConst.MobileKinds.Domain;
using Ju.GundamWars.BizConst.Positions.Domain;
using Ju.GundamWars.BizConst.Roles.Domain;
using Ju.GundamWars.BizConst.Terrains.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.BizConst;

public static class BizConstHosting
{
    // Client で使用
    public static IHostBuilder ConfigureClientBizConst(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // AceImpls
                services
                    // Domain
                    .AddSingleton<AceImplInventory>()
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
