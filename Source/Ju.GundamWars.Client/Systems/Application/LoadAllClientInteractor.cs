using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Commons.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ju.GundamWars.Client.Systems.Application;

internal class LoadAllClientInteractor(
    SystemWebClient gateway,
    ILoadAllClientPresenter presenter,
    IOptions<SystemOption> systemOptions,
    IOptions<MasterUpdateOption> masterUpdateOptions,
    ILogger<LoadAllClientInteractor> logger) : IGw, ILoadAllClientUseCase
{
    private readonly SystemOption systemOption = systemOptions.Value;
    private readonly MasterUpdateOption masterUpdateOption = masterUpdateOptions.Value;
    public Task HandleAsync() =>
        this.Execute(logger, async () =>
        {
            presenter.Initialize();
            presenter.ShowProgress();
            //await Task.Delay(1000);
            try
            {
                var localVersion = await gateway.GetLocalVersionAsync();
                var remoteVersion = await gateway.GetRemoteVersionAsync(masterUpdateOption.MasterDbVersionUri);
                if (string.IsNullOrEmpty(remoteVersion))
                {
                    presenter.AbortVersioning(localVersion, "最新バージョンの取得に失敗しました。");
                }
                else
                {
                    if (remoteVersion != localVersion)
                    {
                        var isSuccessed = await gateway.TryDownloadFileAsync(masterUpdateOption.MasterDbFileUri, systemOption.MasterDbFilePath);
                        if (isSuccessed)
                        {
                            presenter.CompleteVersioning(remoteVersion);
                        }
                        else
                        {
                            presenter.AbortVersioning(localVersion, "最新データの取得に失敗しました。");
                        }
                    }
                }

                var serials = await gateway.SelectAllSerialsAsync();
                presenter.CompleteSerial(serials);

                var skills = await gateway.SelectAllSkillsAsync();
                presenter.CompleteSkill(skills);

                var mobileSSkills = await gateway.SelectAllMobileSSkillsAsync();
                presenter.CompleteMobileSSkill(mobileSSkills);

                var pilotAbilities = await gateway.SelectAllPilotAbilitiesAsync();
                presenter.CompletePilotAbility(pilotAbilities);

                var pilotSkills = await gateway.SelectAllPilotSkillsAsync();
                presenter.CompletePilotSkill(pilotSkills);

                var supportBadges = await gateway.SelectAllSupportBadgesAsync();
                presenter.CompleteSupportBadge(supportBadges);

                var supportSlots = await gateway.SelectAllSupportSlotsAsync();
                presenter.CompleteSupportSlot(supportSlots);

                var tags = await gateway.SelectAllTagsAsync();
                presenter.CompleteTag(tags);

                var coMobiles = await gateway.SelectAllCoMobilesAsync();
                presenter.CompleteCoMobile(coMobiles);

                var cuspas = await gateway.SelectAllCuspasAsync();
                presenter.CompleteCuspa(cuspas);

                var pilots = await gateway.SelectAllPilotsAsync();
                presenter.CompletePilot(pilots);

                var supports = await gateway.SelectAllSupportsAsync();
                presenter.CompleteSupport(supports);

                presenter.Complete();
            }
            finally
            {
                presenter.CloseProgress();
            }
        });
}
