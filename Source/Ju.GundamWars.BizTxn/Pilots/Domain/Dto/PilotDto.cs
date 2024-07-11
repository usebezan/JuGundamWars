using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizConst.Units.Domain;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Dto;

public class PilotDto : IPilot
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitType ForUnit { get; set; } = UnitType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType Grade { get; set; } = GradeType.Grade6;
    public byte Level { get; set; } = 30;
    public int Shooting { get; set; }
    public int Melee { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Awakened { get; set; }
    public int Defense { get; set; }
    public int PracticedShooting { get; set; }
    public int PracticedMelee { get; set; }
    public int PracticedAccuracy { get; set; }
    public int PracticedEvasion { get; set; }
    public int PracticedAwakened { get; set; }
    public int PracticedDefense { get; set; }
    public int SkillId { get; set; } = 1;
    public string? SkillText1 { get; set; }
    public string? SkillText2 { get; set; }
    public int SlotRank1 { get; set; } = 1;
    public int? AbilityId1 { get; set; }
    public int SlotRank2 { get; set; } = 1;
    public int? AbilityId2 { get; set; }
    public int SlotRank3 { get; set; } = 1;
    public int? AbilityId3 { get; set; }
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Navigations

    public List<PilotTagMapDto> TagMaps { get; set; } = [];

    #endregion

}
