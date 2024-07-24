namespace Ju.GundamWars.Share.Skills.Domain;

public abstract record SkillBase : ISkill
{

    #region Primitives

    public int Id { get; set; }
    public SkillGroupType Group { get; set; } = SkillGroupType.Unknown;
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
