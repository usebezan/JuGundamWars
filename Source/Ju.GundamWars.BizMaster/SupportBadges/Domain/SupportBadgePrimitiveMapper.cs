using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizMaster.SupportBadges.Domain;

public class SupportBadgePrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISupportBadgePrimitive
    where TDest : ISupportBadgePrimitive
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Rank = src.Rank;
        dest.BoostStatus = src.BoostStatus;
        dest.CalcMethod = src.CalcMethod;
        dest.Value = src.Value;
        dest.Order = src.Order;
        return dest;
    }
}
