using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.PilotSkills.Domain;

public interface IPilotSkill : IIdentifiable, IOrderable
{

    #region Primitives

    int SkillId { get; set; }

    #endregion

}
