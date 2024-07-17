using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Systems.UseCase.OutputPort;

public interface ILoadAllClientPresenter : IPresenter
{
    void ShowProgress();
    void CloseProgress();

    void CompleteMobileSSkill(List<MobileSSkill> output);
    void CompletePilotAbility(List<PilotAbility> output);
    void CompletePilotSkill(List<PilotSkill> output);
    void CompleteSerial(List<Serial> output);
    void CompleteSkill(List<Skill> output);
    void CompleteSupportBadge(List<SupportBadge> output);
    void CompleteSupportSlot(List<SupportSlot> output);
}
