using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Server.Cuspas.Domain.Service;

public class CuspaTagMapMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ICuspaTagMap
    where TDest : ICuspaTagMap
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.CuspaId = src.CuspaId;
        dest.TagId = src.TagId;
        return dest;
    }
}
