using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.Skills.Domain;

namespace Ju.GundamWars.Client.MobileSSkills.Domain;

public record MobileSSkill : MobileSSkillBase
{

    #region Navigations

    public Skill? Skill { get; set; } = null;

    #endregion

    #region Extensions

    public string SkillGroupText => Skill?.SkillGroupType.ToText() ?? GwText.Unknown;
    public string Name => $"{Skill?.Name}{NameSuffix}";
    public string GradeText => GradeType.ToText();
    public string GradeColor => GradeType.ToColor();

    #endregion

}
