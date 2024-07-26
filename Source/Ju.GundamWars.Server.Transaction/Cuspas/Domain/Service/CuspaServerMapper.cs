using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;

namespace Ju.GundamWars.Server.Cuspas.Domain.Service;

public class CuspaServerMapper<TSrc, TTagLinkSrc, TDest, TTagLinkDest> : CuspaMapperBase<TSrc, CuspaStatusRecord, TDest, CuspaStatusRecord>
    where TSrc : ICuspa<CuspaStatusRecord, TTagLinkSrc>
    where TTagLinkSrc : ICuspaTagLink
    where TDest : ICuspa<CuspaStatusRecord, TTagLinkDest>
    where TTagLinkDest : ICuspaTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.TagLinks.Clear();
        foreach (var srcTagMap in src.TagLinks)
        {
            dest.TagLinks.Add(new() { CuspaId = srcTagMap.CuspaId, TagId = srcTagMap.TagId, });
        }
        return dest;
    }
}
