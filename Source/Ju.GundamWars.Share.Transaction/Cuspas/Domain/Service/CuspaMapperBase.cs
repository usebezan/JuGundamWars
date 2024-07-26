using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Cuspas.Domain.Service;

public abstract class CuspaMapperBase<TSrc, TSrcStatus, TDest, TDestStatus> : IMapper<TSrc, TDest>
    where TSrc : ICuspa<TSrcStatus>
    where TSrcStatus : ICuspaStatus
    where TDest : ICuspa<TDestStatus>
    where TDestStatus : ICuspaStatus
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest MapCore(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.ForUnitType = src.ForUnitType;
        dest.CuspaKindType = src.CuspaKindType;
        dest.Level = src.Level;
        dest.BoostStatusType = src.BoostStatusType;
        dest.BasicValue = src.BasicValue;
        dest.Memo = src.Memo;
        dest.BonusStatus.Set(src.BonusStatus);
        return dest;
    }
}
