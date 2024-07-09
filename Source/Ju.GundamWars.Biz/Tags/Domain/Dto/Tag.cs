using Ju.GundamWars.Core.Ju.GundamWars.Masters.TagGroups;
using Ju.GundamWars.Tags.Domain;

namespace Ju.GundamWars.Tags.Domain.Dto;

public class Tag : ITag
{

    #region Primitives

    public int Id { get; set; }
    public TagGroupType Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
