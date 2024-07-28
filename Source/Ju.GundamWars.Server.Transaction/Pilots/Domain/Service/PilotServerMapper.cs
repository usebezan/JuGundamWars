using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;

namespace Ju.GundamWars.Server.Pilots.Domain.Service;

public class PilotServerMapper<TSrc, TSrcAbility, TSrcTagLink, TDest, TDestAbility, TDestTagLink> : PilotMapperBase<TSrc, PilotStatusRecord, TDest, PilotStatusRecord>
    where TSrc : IPilot<PilotStatusRecord, TSrcAbility, TSrcTagLink>
    where TSrcAbility : IPilotSlotAbility
    where TSrcTagLink : IPilotTagLink
    where TDest : IPilot<PilotStatusRecord, TDestAbility, TDestTagLink>
    where TDestAbility : IPilotSlotAbility, new()
    where TDestTagLink : IPilotTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.PilotSlotAbilities.Clear();
        foreach (var srcAbility in src.PilotSlotAbilities)
        {
            dest.PilotSlotAbilities.Add(new() { PilotId = srcAbility.PilotId, Seq = srcAbility.Seq, SlotRank = srcAbility.SlotRank, PilotAbilityId = srcAbility.PilotAbilityId, });
        }
        dest.TagLinks.Clear();
        foreach (var srcTagLink in src.TagLinks)
        {
            dest.TagLinks.Add(new() { PilotId = srcTagLink.PilotId, TagId = srcTagLink.TagId, });
        }
        return dest;
    }
}
