namespace Ju.GundamWars.Share.Supports.Domain;

public record SupportTagLinkBase : ISupportTagLink
{

    #region Primitives

    public int SupportId { get; set; }
    public int TagId { get; set; }

    #endregion

}
