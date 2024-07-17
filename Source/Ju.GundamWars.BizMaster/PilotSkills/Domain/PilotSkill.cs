using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;

namespace Ju.GundamWars.BizMaster.PilotSkills.Domain;

public record PilotSkill : PilotSkillPrimitiveBase
{

    #region Extensions

    public string GroupText => Skill?.Group.ToText() ?? GwText.Unknown;
    public string Name => Skill?.Name ?? GwText.Unknown;

    #endregion

    public Skill? Skill { get; set; } = null;

}
