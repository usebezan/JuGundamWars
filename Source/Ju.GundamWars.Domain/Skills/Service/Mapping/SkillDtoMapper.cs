using Ju.GundamWars.Domain.Skills.Dto;
using Ju.GundamWars.Domain.Skills.Model;

namespace Ju.GundamWars.Domain.Skills.Service.Mapping;

public class SkillDtoMapper : SkillMapperBase<SkillSubject, Skill>
{
    public override Skill Map(SkillSubject model, Skill dto) =>
        Map(model, dto, null!);
}
