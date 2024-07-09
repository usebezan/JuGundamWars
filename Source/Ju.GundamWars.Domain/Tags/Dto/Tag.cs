namespace Ju.GundamWars.Domain.Tags.Dto;

public class Tag : ITag
{

    #region Primitives

    public int Id { get; set; }
    public TagGroupType Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
