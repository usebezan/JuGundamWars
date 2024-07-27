using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;

namespace Ju.GundamWars.Server.Pilots.Domain.Service;

public class PilotServerMapper<TSrc, TSrcAbility, TTagLinkSrc, TDest, TDestAbility, TTagLinkDest> : PilotMapperBase<TSrc, PilotStatusRecord, TDest, PilotStatusRecord>
    where TSrc : IPilot<PilotStatusRecord, TSrcAbility, TTagLinkSrc>
    where TSrcAbility : IPilotSlotAbility
    where TTagLinkSrc : IPilotTagLink
    where TDest : IPilot<PilotStatusRecord, TDestAbility, TTagLinkDest>
    where TDestAbility : IPilotSlotAbility, new()
    where TTagLinkDest : IPilotTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.Abilities.Clear();
        foreach (var srcAbility in src.Abilities)
        {
            dest.Abilities.Add(new() { PilotId = srcAbility.PilotId, Seq = srcAbility.Seq, SlotRank = srcAbility.SlotRank, PilotAbilityId = srcAbility.PilotAbilityId, });
        }
        dest.TagLinks.Clear();
        foreach (var srcTagLink in src.TagLinks)
        {
            dest.TagLinks.Add(new() { PilotId = srcTagLink.PilotId, TagId = srcTagLink.TagId, });
        }
        return dest;
    }
}
