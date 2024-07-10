using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Service.Mapping;

public abstract class TagMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ITag
    where TDest : ITag
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.Group = src.Group;
        dest.Order = src.Order;
        mapper?.Invoke();
        return dest;
    }
}
