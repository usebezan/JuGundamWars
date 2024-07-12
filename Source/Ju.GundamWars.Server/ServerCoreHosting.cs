using Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Ju.GundamWars.BizTxn.Tags.Domain.Dto;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;
using Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;
using Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;
using Ju.GundamWars.Server.Supports.Infrastructure.Persistence;
using Ju.GundamWars.Server.Tags.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ju.GundamWars.Server;

public static class ClientCoreHosting
{
    public static IHostBuilder ConfigureClientCore(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                var exeDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";
                var masterDbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWarsMaster.db";
                var baseDbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWars.base.db";
                var dbFilePath = $@"{exeDirectoryPath}\Data\JuGundamWars.db";

                if (!File.Exists(dbFilePath))
                {
                    File.Copy(baseDbFilePath, dbFilePath);
                }

                // add DbContext
                services.AddDbContextFactory<GwMasterDbContext>(options =>
                {
#if DEBUG
                    options.EnableSensitiveDataLogging();
#endif
                    // アップデートでファイルを上書きできるように Pooling を False にする
                    options.UseSqlite($@"Filename={masterDbFilePath};Pooling=False");
                });
                services.AddDbContextFactory<GwDbContext>(options =>
                {
#if DEBUG
                    options.EnableSensitiveDataLogging();
#endif
                    options.UseSqlite($@"Filename={dbFilePath}");
                });

                // Infrastructure.Persistence
                services
                    .AddSingleton(typeof(IMasterRepository<>), typeof(MasterRepository<>))
                    .AddSingleton<ITxnRepository<CoMobileDto>, CoMobileRepository>()
                    .AddSingleton<ITxnRepository<CuspaDto>, CuspaRepository>()
                    .AddSingleton<ITxnRepository<PilotDto>, PilotRepository>()
                    .AddSingleton<ITxnRepository<SupportDto>, SupportRepository>()
                    .AddSingleton<ITxnRepository<TagDto>, TagRepository>()
                ;
            });
}
