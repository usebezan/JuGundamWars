using Ju.GundamWars.BizMaster.TagGroups;

namespace Ju.GundamWars.Biz.Tags.Domain.Dto;

public class Tag : ITag
{

    #region Primitives

    public int Id { get; set; }
    public TagGroupType Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
