using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Skills.Dto;
using Ju.GundamWars.Domain.Skills.Model;
using Ju.GundamWars.Domain.Skills.Service.Mapping;

namespace Ju.GundamWars.Domain.Skills.Service.Factory;

public class SkillDtoFactory(SkillDtoMapper mapper) : FactoryBase<SkillSubject, Skill, SkillDtoMapper>(mapper)
{
}
