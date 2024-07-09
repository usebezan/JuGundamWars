using Ju.GundamWars.Domain.Common.Service.Mapping;

namespace Ju.GundamWars.Domain.Tags.Service.Mapping;

public abstract class TagMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ITag
    where TDest : ITag
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Group = src.Group;
        dest.Name = src.Name;
        dest.Order = src.Order;
        mapper?.Invoke();
        return dest;
    }
}
