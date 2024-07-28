using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Supports.Domain.Service;

public abstract class SupportMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISupport
    where TDest : ISupport
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest MapCore(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.ForUnitType = src.ForUnitType;
        dest.SerialId = src.SerialId;
        dest.GradeType = src.GradeType;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        return dest;
    }
}
