using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;

namespace Ju.GundamWars.BizMaster.Commons.Domain;

public class DataDtos
{
    public List<PilotAbilityDto> PilotAbilities { get; set; } = null!;
    public List<SerialDto> Serials { get; set; } = null!;
    public List<SkillDto> Skills { get; set; } = null!;
    public List<SupportBadgeDto> SupportBadges { get; set; } = null!;
}
