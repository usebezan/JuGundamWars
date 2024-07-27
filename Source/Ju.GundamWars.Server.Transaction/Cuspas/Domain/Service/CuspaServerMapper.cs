using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;

namespace Ju.GundamWars.Server.Cuspas.Domain.Service;

public class CuspaServerMapper<TSrc, TSrcTagLink, TDest, TDestTagLink> : CuspaMapperBase<TSrc, CuspaStatusRecord, TDest, CuspaStatusRecord>
    where TSrc : ICuspa<CuspaStatusRecord, TSrcTagLink>
    where TSrcTagLink : ICuspaTagLink
    where TDest : ICuspa<CuspaStatusRecord, TDestTagLink>
    where TDestTagLink : ICuspaTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.TagLinks.Clear();
        foreach (var srcTagLink in src.TagLinks)
        {
            dest.TagLinks.Add(new() { CuspaId = srcTagLink.CuspaId, TagId = srcTagLink.TagId, });
        }
        return dest;
    }
}
