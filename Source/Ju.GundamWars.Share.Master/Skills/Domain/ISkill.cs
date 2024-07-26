using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Skills.Domain;

public interface ISkill : IIdentifiable, IOrderable
{

    #region Primitives

    SkillGroupType SkillGroupType { get; set; }
    string Name { get; set; }

    #endregion

}
