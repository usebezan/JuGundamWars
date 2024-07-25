namespace Ju.GundamWars.Share.Cuspas.Domain;

public record CuspaTagMapBase : ICuspaTagMap
{

    #region Primitives

    public int CuspaId { get; set; }
    public int TagId { get; set; }

    #endregion

}
