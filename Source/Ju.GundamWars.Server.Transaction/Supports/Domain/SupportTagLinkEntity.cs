using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.Supports.Domain;

namespace Ju.GundamWars.Server.Supports.Domain;

public record SupportTagLinkEntity : SupportTagLinkBase
{

    #region Navigations

    public SupportEntity? Support { get; set; }
    public TagEntity? Tag { get; set; }

    #endregion

}
