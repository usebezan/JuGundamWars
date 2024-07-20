using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Service.Mapping;

public abstract class PilotMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IPilot
    where TDest : IPilot
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.ForUnit = src.ForUnit;
        dest.Level = src.Level;
        dest.SkillText1 = src.SkillText1;
        dest.SkillText2 = src.SkillText2;
        dest.SlotRank1 = src.SlotRank1;
        dest.SlotRank2 = src.SlotRank2;
        dest.SlotRank3 = src.SlotRank3;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        mapper?.Invoke();
        return dest;
    }
}
