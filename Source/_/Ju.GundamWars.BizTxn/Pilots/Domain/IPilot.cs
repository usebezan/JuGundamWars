using Ju.GundamWars.BizConst.Units.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizTxn.Pilots.Domain;

public interface IPilot : IIdentify
{
    string Name { get; set; }
    UnitType ForUnit { get; set; }
    byte Level { get; set; }
    string? SkillText1 { get; set; }
    string? SkillText2 { get; set; }
    int SlotRank1 { get; set; }
    int SlotRank2 { get; set; }
    int SlotRank3 { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }
}
