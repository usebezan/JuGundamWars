using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Biz.Supports.Domain.Service.Mapping;

public abstract class SupportMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISupport
    where TDest : ISupport
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.ForUnit = src.ForUnit;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        mapper?.Invoke();
        return dest;
    }
}
