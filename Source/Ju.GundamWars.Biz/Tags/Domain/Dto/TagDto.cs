using Ju.GundamWars.BizMaster.TagGroups.Domain;

namespace Ju.GundamWars.Biz.Tags.Domain.Dto;

public class TagDto : ITag
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TagGroupType Group { get; set; }
    public int Order { get; set; }

    #endregion

}
