using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;

namespace Ju.GundamWars.BizMaster.Commons.Domain;

public class DataModels
{
    public List<PilotAbility> PilotAbilities { get; set; } = null!;
    public List<Serial> Serials { get; set; } = null!;
    public List<Skill> Skills { get; set; } = null!;
    public List<SupportBadge> SupportBadges { get; set; } = null!;
    public List<SupportSlot> SupportSlots { get; set; } = null!;
}
