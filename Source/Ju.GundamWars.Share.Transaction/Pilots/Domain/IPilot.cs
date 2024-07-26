using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Pilots.Domain;

public interface IPilot : IIdentifiable
{

    #region Primitives

    string Name { get; set; }
    UnitType ForUnitType { get; set; }
    int SerialId { get; set; }
    GradeType GradeType { get; set; }
    byte Level { get; set; }
    int Shooting { get; set; }
    int Melee { get; set; }
    int Accuracy { get; set; }
    int Evasion { get; set; }
    int Awakened { get; set; }
    int Defense { get; set; }
    int PracticedShooting { get; set; }
    int PracticedMelee { get; set; }
    int PracticedAccuracy { get; set; }
    int PracticedEvasion { get; set; }
    int PracticedAwakened { get; set; }
    int PracticedDefense { get; set; }
    int SkillId { get; set; }
    string? SkillText1 { get; set; }
    string? SkillText2 { get; set; }
    int SlotRank1 { get; set; }
    int? AbilityId1 { get; set; }
    int SlotRank2 { get; set; }
    int? AbilityId2 { get; set; }
    int SlotRank3 { get; set; }
    int? AbilityId3 { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }

    #endregion

}
