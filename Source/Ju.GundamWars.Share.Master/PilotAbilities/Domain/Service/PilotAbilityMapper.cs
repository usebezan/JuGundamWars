using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.PilotAbilities.Domain.Service;

public class PilotAbilityMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IPilotAbility
    where TDest : IPilotAbility
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Rank = src.Rank;
        dest.BoostCategory = src.BoostCategory;
        dest.BoostStatus = src.BoostStatus;
        dest.CalcMethod = src.CalcMethod;
        dest.Value = src.Value;
        dest.Order = src.Order;
        return dest;
    }
}
