namespace Ju.GundamWars.Share.Supports.Domain;

public record SupportLimitedSerialLinkBase : ISupportLimitedSerialLink
{

    #region Primitives

    public int SupportId { get; set; }
    public int SerialId { get; set; }

    #endregion

}
