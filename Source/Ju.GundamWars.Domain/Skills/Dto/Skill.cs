namespace Ju.GundamWars.Domain.Skills.Dto;

public class Skill : ISkill
{

    #region Primitives

    public int Id { get; set; }
    public SkillGroupType Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
