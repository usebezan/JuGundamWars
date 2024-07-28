using Ju.GundamWars.Share.Supports.Domain;

namespace Ju.GundamWars.Server.Supports.Domain;

public record SupportEntity : SupportBase<SupportLimitedSerialLinkEntity, SupportSlotBadgeEntity, SupportTagLinkEntity>
{
}
