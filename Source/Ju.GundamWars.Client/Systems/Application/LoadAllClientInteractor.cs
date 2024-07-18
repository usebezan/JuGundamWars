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

                //var serials = await gateway.GetAllSerialsAsync();
                //presenter.CompleteSerial(serials);

                //var skills = await gateway.GetAllSkillsAsync();
                //presenter.CompleteSkill(skills);

                //var mobileSSkills = await gateway.GetAllMobileSSkillsAsync();
                //presenter.CompleteMobileSSkill(mobileSSkills);

                //var pilotAbilities = await gateway.GetAllPilotAbilitiesAsync();
                //presenter.CompletePilotAbility(pilotAbilities);

                //var pilotSkills = await gateway.GetAllPilotSkillsAsync();
                //presenter.CompletePilotSkill(pilotSkills);

                //var supportBadges = await gateway.GetAllSupportBadgesAsync();
                //presenter.CompleteSupportBadge(supportBadges);

                //var supportSlots = await gateway.GetAllSupportSlotsAsync();
                //presenter.CompleteSupportSlot(supportSlots);

                var tags = await gateway.GetAllTagsAsync();
                presenter.CompleteTag(tags);

                presenter.Complete();
            }
            finally
            {
                presenter.CloseProgress();
            }
        });
}
