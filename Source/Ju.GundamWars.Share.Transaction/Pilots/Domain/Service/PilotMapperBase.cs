using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Pilots.Domain.Service;

public abstract class PilotMapperBase<TSrc, TSrcStatus, TDest, TDestStatus> : IMapper<TSrc, TDest>
    where TSrc : IPilot<TSrcStatus>
    where TSrcStatus : IPilotStatus
    where TDest : IPilot<TDestStatus>
    where TDestStatus : IPilotStatus
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest MapCore(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.ForUnitType = src.ForUnitType;
        dest.SerialId = src.SerialId;
        dest.GradeType = src.GradeType;
        dest.Level = src.Level;
        dest.PilotSkillId = src.PilotSkillId;
        dest.PilotSkillText1 = src.PilotSkillText1;
        dest.PilotSkillText2 = src.PilotSkillText2;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        dest.BasicStatus.Set(src.BasicStatus);
        dest.PracticedStatus.Set(src.PracticedStatus);
        return dest;
    }
}
