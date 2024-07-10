using Ju.GundamWars.BizMaster.SkillGroups.Domain;

namespace Ju.GundamWars.BizMaster.Skills.Domain.Dto;

public class SkillDto
{

    #region Primitives

    public int Id { get; set; }
    public SkillGroupType Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
