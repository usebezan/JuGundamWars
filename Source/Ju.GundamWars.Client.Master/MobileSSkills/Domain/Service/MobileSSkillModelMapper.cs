using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain.Service;

namespace Ju.GundamWars.Client.MobileSSkills.Domain.Service;

public class MobileSSkillModelMapper(SkillInventory skills) : MobileSSkillMapper<MobileSSkillDto, MobileSSkill>
{
    public new MobileSSkill Map(MobileSSkillDto src, MobileSSkill dest)
    {
        base.Map(src, dest);
        dest.Skill = skills.FirstOrDefault(m => m.Id == src.SkillId);
        return dest;
    }
}
