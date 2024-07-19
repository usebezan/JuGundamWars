using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.Skills.Domain;

namespace Ju.GundamWars.Client.PilotSkills.Domain;

public record PilotSkill : PilotSkillPrimitiveBase
{

    #region Extensions

    public string GroupText => Skill?.Group.ToText() ?? GwText.Unknown;
    public string Name => Skill?.Name ?? GwText.Unknown;

    #endregion

    public Skill? Skill { get; set; } = null;

}
