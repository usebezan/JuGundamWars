using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;

namespace Ju.GundamWars.BizMaster.MobileSSkills.Domain;

public record MobileSSkill : MobileSSkillPrimitiveBase
{

    #region Extensions

    public string GroupText => Skill?.Group.ToText() ?? GwText.Unknown;
    public string Name => $"{Skill?.Name}{NameSuffix}";
    public string GradeText => Grade.ToText();
    public string GradeColor => Grade.ToColor();

    #endregion

    public Skill? Skill { get; set; } = null;

}
