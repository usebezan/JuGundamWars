using Ju.GundamWars.Application.CoMobiles;
using Ju.GundamWars.Application.Cuspas;
using Ju.GundamWars.Application.Mobiles;
using Ju.GundamWars.Application.Pilots;
using Ju.GundamWars.Application.Services;
using Ju.GundamWars.Application.Supports;
using Ju.GundamWars.Application.Systems;
using Ju.GundamWars.Application.Tags;
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

            services.AddSingleton<CoMobileMapper>();
            services.AddSingleton<CoMobileFactory>();
            services.AddSingleton<CoMobileSubjectMapper>();
            services.AddSingleton<CoMobileSubjectFactory>();
            services.AddSingleton<IInsertCoMobileUseCase, InsertCoMobileInteractor>();
            services.AddSingleton<IUpdateCoMobileUseCase, UpdateCoMobileInteractor>();
            services.AddSingleton<IDeleteCoMobileUseCase, DeleteCoMobileInteractor>();
            services.AddSingleton<ICancelCoMobileUseCase, CancelCoMobileInteractor>();

            services.AddSingleton<CuspaMapper>();
            services.AddSingleton<CuspaFactory>();
            services.AddSingleton<CuspaSubjectMapper>();
            services.AddSingleton<CuspaSubjectFactory>();
            services.AddSingleton<IInsertCuspaUseCase, InsertCuspaInteractor>();
            services.AddSingleton<IUpdateCuspaUseCase, UpdateCuspaInteractor>();
            services.AddSingleton<IDeleteCuspaUseCase, DeleteCuspaInteractor>();
            services.AddSingleton<ICancelCuspaUseCase, CancelCuspaInteractor>();

            services.AddSingleton<MobileMapper>();
            services.AddSingleton<MobileFactory>();
            services.AddSingleton<MobileSubjectMapper>();
            services.AddSingleton<MobileSubjectFactory>();
            services.AddSingleton<IInsertMobileUseCase, InsertMobileInteractor>();
            services.AddSingleton<IUpdateMobileUseCase, UpdateMobileInteractor>();
            services.AddSingleton<IDeleteMobileUseCase, DeleteMobileInteractor>();
            services.AddSingleton<ICancelMobileUseCase, CancelMobileInteractor>();

            services.AddSingleton<PilotMapper>();
            services.AddSingleton<PilotFactory>();
            services.AddSingleton<PilotSubjectMapper>();
            services.AddSingleton<PilotSubjectFactory>();
            services.AddSingleton<IInsertPilotUseCase, InsertPilotInteractor>();
            services.AddSingleton<IUpdatePilotUseCase, UpdatePilotInteractor>();
            services.AddSingleton<IDeletePilotUseCase, DeletePilotInteractor>();
            services.AddSingleton<ICancelPilotUseCase, CancelPilotInteractor>();

            services.AddSingleton<SupportMapper>();
            services.AddSingleton<SupportFactory>();
            services.AddSingleton<SupportSubjectMapper>();
            services.AddSingleton<SupportSubjectFactory>();
            services.AddSingleton<IInsertSupportUseCase, InsertSupportInteractor>();
            services.AddSingleton<IUpdateSupportUseCase, UpdateSupportInteractor>();
            services.AddSingleton<IDeleteSupportUseCase, DeleteSupportInteractor>();
            services.AddSingleton<ICancelSupportUseCase, CancelSupportInteractor>();

            services.AddSingleton<TagFactory>();
            services.AddSingleton<TagSubjectMapper>();
            services.AddSingleton<TagSubjectFactory>();
            services.AddSingleton<IUpdateTagsUseCase, UpdateTagsInteractor>();

            services.AddSingleton<IDownloadDataUseCase, DownloadDataInteractor>();
            services.AddSingleton<ILoadAllUseCase, LoadAllInteractor>();
            services.AddSingleton<ILoadConstDataUseCase, LoadConstDataUseCaseInteractor>();
            services.AddSingleton<ILoadUserDataUseCase, LoadUserDataInteractor>();
            services.AddSingleton<IReloadAllUseCase, ReloadAllInteractor>();
        });

}
