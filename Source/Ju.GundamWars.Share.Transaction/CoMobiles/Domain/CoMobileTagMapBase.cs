namespace Ju.GundamWars.Share.CoMobiles.Domain;

public record CoMobileTagMapBase : ICoMobileTagMap
{

    #region Primitives

    public int CoMobileId { get; set; }
    public int TagId { get; set; }

    #endregion

}
