namespace Ju.GundamWars.BizMaster.PilotSkills.Domain;

public record PilotSkillPrimitiveBase : IPilotSkillPrimitive
{

    #region Primitives

    public int Id { get; set; }
    public int SkillId { get; set; }
    public int Order { get; set; }

    #endregion

}
