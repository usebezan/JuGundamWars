using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.MobileSSkills.Domain;

public class MobileSSkillPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IMobileSSkillPrimitive
    where TDest : IMobileSSkillPrimitive
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
