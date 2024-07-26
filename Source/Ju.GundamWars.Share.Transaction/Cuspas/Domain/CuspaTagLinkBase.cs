namespace Ju.GundamWars.Share.Cuspas.Domain;

public abstract record CuspaTagLinkBase : ICuspaTagLink
{

    #region Primitives

    public int CuspaId { get; set; }
    public int TagId { get; set; }

    #endregion

}
