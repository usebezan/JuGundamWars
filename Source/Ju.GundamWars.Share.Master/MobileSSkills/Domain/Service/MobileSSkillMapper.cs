using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.MobileSSkills.Domain.Service;

public class MobileSSkillMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IMobileSSkill
    where TDest : IMobileSSkill
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.SkillId = src.SkillId;
        dest.NameSuffix = src.NameSuffix;
        dest.Grade = src.Grade;
        dest.Order = src.Order;
        return dest;
    }
}
