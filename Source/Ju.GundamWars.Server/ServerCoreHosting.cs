using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Server.Commons.Application;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Systems.Infrastructure.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ju.GundamWars.Server;

public static class ServerCoreHosting
{
    public static IHostBuilder ConfigureServerCore(this IHostBuilder self) =>
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
                services.AddDbContextFactory<GwTxnDbContext>(options =>
                {
#if DEBUG
                    options.EnableSensitiveDataLogging();
#endif
                    options.UseSqlite($@"Filename={dbFilePath}");
                });

                // Commons
                services
                    // Application
                    .AddSingleton(typeof(IDeleteByIdServerUseCase<,>), typeof(DeleteByIdServerInteractor<,>))
                    .AddSingleton(typeof(IInsertServerUseCase<,,,>), typeof(InsertServerInteractor<,,,>))
                    .AddSingleton(typeof(ISelectAllServerUseCase<,>), typeof(SelectAllServerInteractor<,>))
                    .AddSingleton(typeof(ISelectByIdServerUseCase<,>), typeof(SelectByIdServerInteractor<,>))
                    .AddSingleton(typeof(IUpdateServerUseCase<,,,>), typeof(UpdateServerInteractor<,,,>))
                    // Infrastructure.Persistence
                    .AddSingleton(typeof(IMasterRepository<>), typeof(MasterRepository<>))
                ;

                // Systems
                services
                    // Domain
                    .AddSingleton(typeof(MobileSSkillPrimitiveMapper<,>))
                    .AddSingleton(typeof(PilotAbilityPrimitiveMapper<,>))
                    .AddSingleton(typeof(SerialPrimitiveMapper<,>))
                    .AddSingleton(typeof(SkillPrimitiveMapper<,>))
                    .AddSingleton(typeof(SupportBadgePrimitiveMapper<,>))
                    .AddSingleton(typeof(SupportSlotPrimitiveMapper<,>))
                    // Infrastructure.WebApi
                    .AddSingleton<SystemWebApiController>()
                ;
            });
}

//.AddSingleton<ITxnRepository<CoMobileDto>, CoMobileRepository>()
//.AddSingleton<ITxnRepository<CuspaDto>, CuspaRepository>()
//.AddSingleton<ITxnRepository<PilotDto>, PilotRepository>()
//.AddSingleton<ITxnRepository<SupportDto>, SupportRepository>()
//.AddSingleton<ITxnRepository<TagDto>, TagRepository>()
