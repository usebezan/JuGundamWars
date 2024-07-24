using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain;

public record CoMobileTagMapEntity : CoMobileTagMapBase
{

    #region Navigations

    public CoMobileEntity? CoMobile { get; set; }
    public TagEntity? Tag { get; set; }

    #endregion

}
