namespace Ju.GundamWars.Domain.Skills;

public interface ISkill : IIdentify
{
    SkillGroupType Group { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
