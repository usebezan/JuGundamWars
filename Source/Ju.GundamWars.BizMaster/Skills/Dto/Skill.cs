using Ju.GundamWars.BizMaster.SkillGroups.Dto;

namespace Ju.GundamWars.BizMaster.Skills.Dto;

public class Skill
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

    #region Navigations

    public SkillGroup? Group { get; set; } = null;

    #endregion

}
