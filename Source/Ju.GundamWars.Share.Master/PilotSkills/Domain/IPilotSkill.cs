using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.PilotSkills.Domain;

public interface IPilotSkill : IIdentify, IOrderable
{

    #region Primitives

    int SkillId { get; set; }

    #endregion

}
