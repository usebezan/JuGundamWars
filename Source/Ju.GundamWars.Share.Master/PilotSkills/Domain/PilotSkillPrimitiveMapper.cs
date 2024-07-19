using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.PilotSkills.Domain;

public class PilotSkillPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IPilotSkillPrimitive
    where TDest : IPilotSkillPrimitive
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.SkillId = src.SkillId;
        dest.Order = src.Order;
        return dest;
    }
}
