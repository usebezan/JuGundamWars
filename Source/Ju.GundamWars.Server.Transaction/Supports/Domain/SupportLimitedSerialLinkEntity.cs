using Ju.GundamWars.Server.Serials.Domain;
using Ju.GundamWars.Share.Supports.Domain;

namespace Ju.GundamWars.Server.Supports.Domain;

public record SupportLimitedSerialLinkEntity : SupportLimitedSerialLinkBase
{

    #region Navigations

    public SupportEntity? Support { get; set; }
    public SerialEntity? Serial { get; set; }

    #endregion

}
