using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Application.Tags.Repositories;
using Ju.GundamWars.Persistence2.CoMobiles;
using Ju.GundamWars.Persistence2.Cuspas;
using Ju.GundamWars.Persistence2.Mobiles;
using Ju.GundamWars.Persistence2.Pilots;
using Ju.GundamWars.Persistence2.Supports;
using Ju.GundamWars.Persistence2.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ju.GundamWars.Persistence2;

public static class Persistence2Hosting
{

    public static IHostBuilder ConfigurePersistence2Services(this IHostBuilder self) =>
        self.ConfigureServices((context, services) =>
        {
            var exeDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";
            var dbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWars.db";
            var baseDbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWars.base.db";

            if (!File.Exists(dbFilePath))
            {
                File.Copy(baseDbFilePath, dbFilePath);
            }
            services.AddDbContextFactory<GwDbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging();
#endif
                options.UseSqlite($@"Filename={dbFilePath}");
            });

            services.AddSingleton<ICoUnitRepository, CoUnitRepository>();
            services.AddSingleton<ICuspaRepository, CuspaRepository>();
            services.AddSingleton<IMobileRepository, MobileRepository>();
            services.AddSingleton<IPilotRepository, PilotRepository>();
            services.AddSingleton<ISupportRepository, SupportRepository>();
            services.AddSingleton<ITagRepository, TagRepository>();
        });

}
