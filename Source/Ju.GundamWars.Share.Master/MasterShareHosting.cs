using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.Serials.Domain;
using Ju.GundamWars.Share.Skills.Domain;
using Ju.GundamWars.Share.SupportBadges.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;
using Ju.GundamWars.Share.Versionings.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Share;

public static class MasterShareHosting
{
    public static IHostBuilder ConfigureMasterShare(this IHostBuilder self) =>
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
}
