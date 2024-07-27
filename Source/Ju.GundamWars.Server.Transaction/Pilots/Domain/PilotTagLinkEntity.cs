using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Server.Pilots.Domain;

public record PilotTagLinkEntity : PilotTagLinkBase
{

    #region Navigations

    public PilotEntity? Pilot { get; set; }
    public TagEntity? Tag { get; set; }

    #endregion

}
