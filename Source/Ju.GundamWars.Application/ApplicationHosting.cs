using Ju.GundamWars.Application.CoMobiles;
using Ju.GundamWars.Application.Cuspas;
using Ju.GundamWars.Application.Mobiles;
using Ju.GundamWars.Application.Pilots;
using Ju.GundamWars.Application.Services;
using Ju.GundamWars.Application.Supports;
using Ju.GundamWars.Application.Systems;
using Ju.GundamWars.Application.Tags;
using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Factories;
using Ju.GundamWars.Domain.Cuspas.Appliers;
using Ju.GundamWars.Domain.Cuspas.Factories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Mobiles.Factories;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Factories;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Supports.Factories;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Tags.Appliers;
using Ju.GundamWars.Domain.Tags.Factories;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Application;

public static class ApplicationHosting
{

    // Inventory は、複数スレッドからコレクション操作できるようにするため App 側で追加する（PresentationFramework.dll の参照が必要）
    public static IHostBuilder ConfigureApplicationServices(this IHostBuilder self) =>
        self.ConfigureServices((context, services) =>
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<HttpService>();

            services.AddSingleton<WindowStatus>();

            services.AddSingleton<CoMobileApplier>();
            services.AddSingleton<CoMobileFactory>();
            services.AddSingleton<CoMobileSubjectApplier>();
            services.AddSingleton<CoMobileSubjectFactory>();
            services.AddSingleton<IInsertCoMobileUseCase, InsertCoMobileInteractor>();
            services.AddSingleton<IUpdateCoMobileUseCase, UpdateCoMobileInteractor>();
            services.AddSingleton<IDeleteCoMobileUseCase, DeleteCoMobileInteractor>();
            services.AddSingleton<ICancelCoMobileUseCase, CancelCoMobileInteractor>();

            services.AddSingleton<CuspaApplier>();
            services.AddSingleton<CuspaFactory>();
            services.AddSingleton<CuspaSubjectApplier>();
            services.AddSingleton<CuspaSubjectFactory>();
            services.AddSingleton<IInsertCuspaUseCase, InsertCuspaInteractor>();
            services.AddSingleton<IUpdateCuspaUseCase, UpdateCuspaInteractor>();
            services.AddSingleton<IDeleteCuspaUseCase, DeleteCuspaInteractor>();
            services.AddSingleton<ICancelCuspaUseCase, CancelCuspaInteractor>();

            services.AddSingleton<MobileApplier>();
            services.AddSingleton<MobileFactory>();
            services.AddSingleton<MobileSubjectApplier>();
            services.AddSingleton<MobileSubjectFactory>();
            services.AddSingleton<IInsertMobileUseCase, InsertMobileInteractor>();
            services.AddSingleton<IUpdateMobileUseCase, UpdateMobileInteractor>();
            services.AddSingleton<IDeleteMobileUseCase, DeleteMobileInteractor>();
            services.AddSingleton<ICancelMobileUseCase, CancelMobileInteractor>();

            services.AddSingleton<PilotApplier>();
            services.AddSingleton<PilotFactory>();
            services.AddSingleton<PilotSubjectApplier>();
            services.AddSingleton<PilotSubjectFactory>();
            services.AddSingleton<IInsertPilotUseCase, InsertPilotInteractor>();
            services.AddSingleton<IUpdatePilotUseCase, UpdatePilotInteractor>();
            services.AddSingleton<IDeletePilotUseCase, DeletePilotInteractor>();
            services.AddSingleton<ICancelPilotUseCase, CancelPilotInteractor>();

            services.AddSingleton<SupportApplier>();
            services.AddSingleton<SupportFactory>();
            services.AddSingleton<SupportSubjectApplier>();
            services.AddSingleton<SupportSubjectFactory>();
            services.AddSingleton<IInsertSupportUseCase, InsertSupportInteractor>();
            services.AddSingleton<IUpdateSupportUseCase, UpdateSupportInteractor>();
            services.AddSingleton<IDeleteSupportUseCase, DeleteSupportInteractor>();
            services.AddSingleton<ICancelSupportUseCase, CancelSupportInteractor>();

            services.AddSingleton<TagFactory>();
            services.AddSingleton<TagSubjectApplier>();
            services.AddSingleton<TagSubjectFactory>();
            services.AddSingleton<IUpdateTagsUseCase, UpdateTagsInteractor>();

            services.AddSingleton<IDownloadDataUseCase, DownloadDataInteractor>();
            services.AddSingleton<ILoadAllUseCase, LoadAllInteractor>();
            services.AddSingleton<ILoadConstDataUseCase, LoadConstDataUseCaseInteractor>();
            services.AddSingleton<ILoadUserDataUseCase, LoadUserDataInteractor>();
            services.AddSingleton<IReloadAllUseCase, ReloadAllInteractor>();
        });

}
