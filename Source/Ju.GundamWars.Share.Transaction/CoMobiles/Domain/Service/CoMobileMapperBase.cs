using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.CoMobiles.Domain.Service;

public abstract class CoMobileMapperBase<TSrc, TSrcStatus, TSrcCount, TDest, TDestStatus, TDestCount> : IMapper<TSrc, TDest>
    where TSrc : ICoMobile<TSrcStatus, TSrcCount>
    where TSrcStatus : ICoMobileStatus
    where TSrcCount : ICoMobileUpgradedCount
    where TDest : ICoMobile<TDestStatus, TDestCount>
    where TDestStatus : ICoMobileStatus
    where TDestCount : ICoMobileUpgradedCount
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest MapCore(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.SerialId = src.SerialId;
        dest.RoleType = src.RoleType;
        dest.Level = src.Level;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        dest.BasicStatus.Set(src.BasicStatus);
        dest.UpgradedStatus.Set(src.UpgradedStatus);
        dest.UpgradedCount.Set(src.UpgradedCount);
        return dest;
    }
}
