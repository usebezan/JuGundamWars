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
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Systems.UseCase.OutputPort;

public interface ILoadAllClientPresenter : IPresenter, IProgressivePresenter
{
    void CompleteMobileSSkill(List<MobileSSkill> output);
    void CompletePilotAbility(List<PilotAbility> output);
    void CompletePilotSkill(List<PilotSkill> output);
    void CompleteSerial(List<Serial> output);
    void CompleteSkill(List<Skill> output);
    void CompleteSupportBadge(List<SupportBadge> output);
    void CompleteSupportSlot(List<SupportSlot> output);

    void CompleteVersioning(string output);

    void CompleteTag(List<Tag> output);

    void CompleteCoMobile(List<CoMobile> output);
    void CompleteCuspa(List<Cuspa> output);
    void CompletePilot(List<Pilot> output);
    void CompleteSupport(List<Support> output);
}
