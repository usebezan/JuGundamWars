using Ju.GundamWars.Domain.Common.Service.Mapping;
using Ju.GundamWars.Domain.Skills;

namespace Ju.GundamWars.Domain.Skills.Service.Mapping;

public abstract class SkillMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISkill
    where TDest : ISkill
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.Group = src.Group;
        dest.Name = src.Name;
        dest.Order = src.Order;
        mapper?.Invoke();
        return dest;
    }
}
