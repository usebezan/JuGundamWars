using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.Versionings.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.BizMaster;

public static class BizMasterHosting
{
    // Server、Client 両方で使用
    public static IHostBuilder ConfigureBizMaster(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // MobileSSkills
                services
                    // Domain
                    .AddSingleton(typeof(MobileSSkillPrimitiveMapper<,>))
                ;
                // PilotAbilities
                services
                    // Domain
                    .AddSingleton(typeof(PilotAbilityPrimitiveMapper<,>))
                ;
                // PilotSkills
                services
                    // Domain
                    .AddSingleton(typeof(PilotSkillPrimitiveMapper<,>))
                ;
                // Serials
                services
                    // Domain
                    .AddSingleton(typeof(SerialPrimitiveMapper<,>))
                ;
                // Skills
                services
                    // Domain
                    .AddSingleton(typeof(SkillPrimitiveMapper<,>))
                ;
                // SupportBadges
                services
                    // Domain
                    .AddSingleton(typeof(SupportBadgePrimitiveMapper<,>))
                ;
                // SupportSlots
                services
                    // Domain
                    .AddSingleton(typeof(SupportSlotPrimitiveMapper<,>))
                ;
                // Versionings
                services
                    // Domain
                    .AddSingleton(typeof(VersioningPrimitiveMapper<,>))
                ;
            });
    // Client で使用
    public static IHostBuilder ConfigureClientBizMaster(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // MobileSSkills
                services
                    // Domain
                    .AddSingleton<MobileSSkillInventory>()
                    .AddSingleton<MobileSSkillModelMapper>()
                ;
                // PilotAbilities
                services
                    // Domain
                    .AddSingleton<PilotAbilityInventory>()
                ;
                // PilotSkills
                services
                    // Domain
                    .AddSingleton<PilotSkillInventory>()
                    .AddSingleton<PilotSkillModelMapper>()
                ;
                // Serials
                services
                    // Domain
                    .AddSingleton<SerialInventory>()
                ;
                // Skills
                services
                    // Domain
                    .AddSingleton<SkillInventory>()
                ;
                // SupportBadges
                services
                    // Domain
                    .AddSingleton<SupportBadgeInventory>()
                ;
                // SupportSlots
                services
                    // Domain
                    .AddSingleton<SupportSlotInventory>()
                ;
            });
}
