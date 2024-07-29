using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Systems.View;

namespace Ju.GundamWars.Systems.Presentation;

internal class LoadAllPresenter(
    ViewState windowState,
    LoadAllProgressViewModel loadAllProgressViewModel,
    MobileSSkillInventory mobileSSkills,
    PilotAbilityInventory pilotAbilities,
    PilotSkillInventory pilotSkills,
    SerialInventory serials,
    SkillInventory skills,
    SupportBadgeInventory supportBadges,
    SupportSlotInventory supportSlots,
    CoMobileInventory coMobiles,
    CuspaInventory cuspas,
    PilotInventory pilots,
    SupportInventory supports,
    TagInventory tags) : ILoadAllClientPresenter
{

    public void Initialize()
    {
        // TODO: ?
    }
    public void ShowProgress()
    {
        loadAllProgressViewModel.IsIndeterminate = true;
        windowState.DialogContent = loadAllProgressViewModel;
        windowState.IsDialogOpen = true;
    }
    public void CloseProgress()
    {
        windowState.IsDialogOpen = false;
        loadAllProgressViewModel.IsIndeterminate = false;
    }
    public void ValidationError(string _)
    {
        // Do nothing.
    }
    public void Cancel()
    {
        // Do nothing.
    }
    public void Complete()
    {
        // Do nothing.
    }

    #region Master

    public void CompleteMobileSSkill(List<MobileSSkill> output) =>
        mobileSSkills.ReAddRange(output);
    public void CompletePilotAbility(List<PilotAbility> output) =>
        pilotAbilities.ReAddRange(output);
    public void CompletePilotSkill(List<PilotSkill> output) =>
        pilotSkills.ReAddRange(output);
    public void CompleteSerial(List<Serial> output) =>
        serials.ReAddRange(output);
    public void CompleteSkill(List<Skill> output) =>
        skills.ReAddRange(output);
    public void CompleteSupportBadge(List<SupportBadge> output) =>
        supportBadges.ReAddRange(output);
    public void CompleteSupportSlot(List<SupportSlot> output) =>
        supportSlots.ReAddRange(output);

    public void CompleteVersioning(string output)
    {
        windowState.Version = output;
    }

    #endregion

    #region Transaction

    public void CompleteCoMobile(List<CoMobile> output) =>
        coMobiles.ReAddRange(output);
    public void CompleteCuspa(List<Cuspa> output) =>
        cuspas.ReAddRange(output);
    public void CompletePilot(List<Pilot> output) =>
        pilots.ReAddRange(output);
    public void CompleteSupport(List<Support> output) =>
        supports.ReAddRange(output);
    public void CompleteTag(List<Tag> output) =>
        tags.ReAddRange(output);

    #endregion

}
