using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Pilots.Domain;

public record PilotBase<TAbility, TTagLink> : IPilot<PilotStatusRecord, TAbility, TTagLink>
    where TAbility : IPilotSlotAbility
    where TTagLink : IPilotTagLink
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitType ForUnitType { get; set; } = UnitType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType GradeType { get; set; } = GradeType.Grade6;
    public byte Level { get; set; } = 30;
    public PilotStatusRecord BasicStatus { get; set; } = new();
    public PilotStatusRecord PracticedStatus { get; set; } = new();
    public int PilotSkillId { get; set; } = 1;
    public string? PilotSkillText1 { get; set; }
    public string? PilotSkillText2 { get; set; }
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Navigations

    public List<TAbility> Abilities { get; set; } = [];
    public List<TTagLink> TagLinks { get; set; } = [];

    #endregion

}
