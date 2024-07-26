namespace Ju.GundamWars.Share.PilotSkills.Domain;

public abstract record PilotSkillBase : IPilotSkill
{

    #region Primitives

    public int Id { get; set; }
    public int SkillId { get; set; }
    public int Order { get; set; }

    #endregion

}
