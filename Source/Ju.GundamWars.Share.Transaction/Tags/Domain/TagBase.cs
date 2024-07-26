namespace Ju.GundamWars.Share.Tags.Domain;

public record TagBase : ITag
{

    #region Primitives

    public int Id { get; set; }
    public TagGroupType TagGroupType { get; set; }
    public string? Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
