using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Application.Systems.Repositories;
using Ju.GundamWars.Application.Versionings.Repositories;
using Ju.GundamWars.Persistence.Mobiles;
using Ju.GundamWars.Persistence.Pilots;
using Ju.GundamWars.Persistence.Serials;
using Ju.GundamWars.Persistence.Supports;
using Ju.GundamWars.Persistence.Versionings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ju.GundamWars.Persistence;

public static class PersistenceHosting
{

    public static IHostBuilder ConfigurePersistenceServices(this IHostBuilder self) =>
        self.ConfigureServices((context, services) =>
        {
            var exeDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";
            var masterDbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWarsMaster.db";

            // add DbContext
            services.AddDbContextFactory<GwMasterDbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging();
#endif
                // アップデートでファイルを上書きできるように Pooling を False にする
                options.UseSqlite($@"Filename={masterDbFilePath};Pooling=False");
            });

            services.AddSingleton<IMobileSSkillRepository, MobileSSkillRepository>();
            services.AddSingleton<IPilotAbilityRepository, PilotAbilityRepository>();
            services.AddSingleton<IPilotSkillRepository, PilotSkillRepository>();
            services.AddSingleton<ISerialRepository, SerialRepository>();
            services.AddSingleton<ISupportBadgeRepository, SupportBadgeRepository>();
            services.AddSingleton<ISupportSlotRepository, SupportSlotRepository>();
            services.AddSingleton<IVersioningRepository, VersioningRepository>();
        });

}
