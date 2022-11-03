using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;


namespace Ju.GundamWars
{

    public static class CoreHosting
    {

        private static readonly string masterDbName = "GundamWars.master.db";
        private static readonly string userDbName = "GundamWars.db";


        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var masterDbFile = $@"{currentDirectory}\data\{masterDbName}";
            var userDbFile = $@"{currentDirectory}\data\{userDbName}";

            if (!File.Exists(userDbFile))
            {
                File.Copy(masterDbFile, userDbFile);
            }
            
            // add DbContext
            services
                .AddDbContext<GwDbContext>(options =>
                {
#if DEBUG
                    options.EnableSensitiveDataLogging();
                    options.LogTo(m => Debug.WriteLine(m));
#endif
                    options.UseSqlite($@"Filename={userDbFile}");
                });

            // add services:
            services.AddSingleton<MobileArmorRepository>();
            services.AddSingleton<MobileSuitRepository>();
            services.AddSingleton<PilotAbilityRepository>();
            services.AddSingleton<PilotRepository>();
            services.AddSingleton<PilotSkillRepository>();
            services.AddSingleton<SerialRepository>();
            services.AddSingleton<SupportBadgeRepository>();
            services.AddSingleton<SupportRepository>();
            services.AddSingleton<SupportSlotRepository>();
            services.AddSingleton<UnitSAbilityRepository>();
        }

    }

}
