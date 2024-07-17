using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;

namespace Ju.GundamWars.BizMaster.Commons.Domain;

public class DataEntities
{
    public List<PilotAbilityEntity> PilotAbilities { get; set; } = null!;
    public List<SerialEntity> Serials { get; set; } = null!;
    public List<SkillEntity> Skills { get; set; } = null!;
    public List<SupportBadgeEntity> SupportBadges { get; set; } = null!;
    public List<SupportSlotEntity> SupportSlots { get; set; } = null!;
}
