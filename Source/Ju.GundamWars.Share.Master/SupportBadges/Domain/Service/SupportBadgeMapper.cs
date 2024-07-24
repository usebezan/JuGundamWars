using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.SupportBadges.Domain.Service;

public class SupportBadgeMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISupportBadge
    where TDest : ISupportBadge
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
