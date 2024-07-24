using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.PilotSkills.Domain.Service;

public class PilotSkillMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IPilotSkill
    where TDest : IPilotSkill
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.SkillId = src.SkillId;
        dest.Order = src.Order;
        return dest;
    }
}
