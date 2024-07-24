using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.SupportSlots.Domain.Service;

public class SupportSlotMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISupportSlot
    where TDest : ISupportSlot
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Kind = src.Kind;
        dest.BoostStatus = src.BoostStatus;
        dest.CalcMethod = src.CalcMethod;
        dest.Value = src.Value;
        dest.Order = src.Order;
        return dest;
    }
}
