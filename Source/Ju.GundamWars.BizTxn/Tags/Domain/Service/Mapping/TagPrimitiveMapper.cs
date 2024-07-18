using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Service.Mapping;

public class TagPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ITag
    where TDest : ITag
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Group = src.Group;
        dest.Name = src.Name;
        dest.Order = src.Order;
        return dest;
    }
}
