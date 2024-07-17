using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.PilotSkills.Domain;

public interface IPilotSkillPrimitive : IIdentify, IOrderable
{

    #region Primitives

    int SkillId { get; set; }

    #endregion

}
