using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Skills.Domain;

public interface ISkillPrimitive : IIdentify, IOrderable
{

    #region Primitives

    SkillGroupType Group { get; set; }
    string Name { get; set; }

    #endregion

}
