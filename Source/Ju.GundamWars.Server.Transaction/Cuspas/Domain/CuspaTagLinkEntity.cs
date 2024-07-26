using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Server.Cuspas.Domain;

public record CuspaTagLinkEntity : CuspaTagLinkBase
{

    #region Navigations

    public CuspaEntity? Cuspa { get; set; }
    public TagEntity? Tag { get; set; }

    #endregion

}
