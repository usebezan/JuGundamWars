using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Application;

internal class LoadAllClientInteractor(SystemWebClient gateway, ILoadAllClientPresenter presenter, ILogger<LoadAllClientInteractor> logger) : IGw, ILoadAllClientUseCase
{
    public Task HandleAsync() =>
        this.Execute(logger, async () =>
        {
            presenter.ShowProgress();
            try
            {
                //// TODO: message etc...
                //var remoteVersion = await gateway.GetRemoteVersionAsync("https://raw.githubusercontent.com/usebezan/JuGundamWarsData/main/MasterData.ver");
                //var localVersion = await gateway.GetLocalVersionAsync();
                //if (remoteVersion != localVersion)
                //{
                //    var masterDbFilePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "."}\Data\JuGundamWarsMaster.db";
                //    await gateway.TryDownloadFileAsync("https://raw.githubusercontent.com/usebezan/JuGundamWarsData/main/MasterData.db", masterDbFilePath);
                //}
                //presenter.CompleteVersioning(remoteVersion);
                var localVersion = await gateway.GetLocalVersionAsync();
                presenter.CompleteVersioning(localVersion);

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
