using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain.Service.Mapping;

public abstract class CoMobileMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ICoMobile
    where TDest : ICoMobile
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.Level = src.Level;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        mapper?.Invoke();
        return dest;
    }
}
