using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Skills.Domain;

public class SkillDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public SkillGroupType Group { get; set; } = SkillGroupType.Unknown;
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
