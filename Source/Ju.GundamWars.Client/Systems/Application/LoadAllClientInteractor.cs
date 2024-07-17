using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Application;

internal class LoadAllClientInteractor(
    SystemWebClient gateway,
    ILoadAllClientPresenter presenter,
    ILogger<LoadAllClientInteractor> logger)
    : IGw, ILoadAllClientUseCase
{
    public Task HandleAsync() =>
        this.Execute(logger, async () =>
        {
            presenter.ShowProgress();
            try
            {
                //var serials = await gateway.SelectAllSerialsAsync();
                //presenter.CompleteSerial(serials);

                var skills = await gateway.SelectAllSkillsAsync();
                presenter.CompleteSkill(skills);

                var mobileSSkills = await gateway.SelectAllMobileSSkillsAsync();
                presenter.CompleteMobileSSkill(mobileSSkills);

                //var pilotAbilities = await gateway.SelectAllPilotAbilitiesAsync();
                //presenter.CompletePilotAbility(pilotAbilities);

                //var supportBadges = await gateway.SelectAllSupportBadgesAsync();
                //presenter.CompleteSupportBadge(supportBadges);

                //var supportSlots = await gateway.SelectAllSupportSlotsAsync();
                //presenter.CompleteSupportSlot(supportSlots);
            }
            finally
            {
                presenter.CloseProgress();
            }
        });
}
