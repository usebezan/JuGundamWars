namespace Ju.GundamWars.Share.CoMobiles.Domain;

public abstract record CoMobileTagLinkBase : ICoMobileTagLink
{

    #region Primitives

    public int CoMobileId { get; set; }
    public int TagId { get; set; }

    #endregion

}
