using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Skills.Domain;

public class SkillPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISkillPrimitive
    where TDest : ISkillPrimitive
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Group = src.Group;
        dest.Name = src.Name;
        dest.Order = src.Order;
        return dest;
    }
}
