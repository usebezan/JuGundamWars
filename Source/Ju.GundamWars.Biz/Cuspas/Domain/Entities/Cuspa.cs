using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.CuspaKinds;

namespace Ju.GundamWars.Cuspas.Domain.Entities;

public class Cuspa : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryType Category { get; set; } = CategoryType.MobileSuit;
    public CuspaKindType Kind { get; set; } = CuspaKindType.Hp2;
    public byte Level { get; set; } = 10;
    public int Hp { get; set; }
    public int BeamAttack { get; set; }
    public int PhysicalAttack { get; set; }
    public int BeamDefence { get; set; }
    public int PhysicalDefence { get; set; }
    public int CriticalRate { get; set; }
    public int CriticalDamage { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Mobility { get; set; }
    public int EnRecovery { get; set; }
    public int BonusHp { get; set; }
    public int BonusBeamAttack { get; set; }
    public int BonusPhysicalAttack { get; set; }
    public int BonusBeamDefence { get; set; }
    public int BonusPhysicalDefence { get; set; }
    public int BonusCriticalRate { get; set; }
    public int BonusCriticalDamage { get; set; }
    public int BonusAccuracy { get; set; }
    public int BonusEvasion { get; set; }
    public int BonusMobility { get; set; }
    public int BonusEnRecovery { get; set; }
    public string? Memo { get; set; }

    public List<CuspaTagMap> TagMaps { get; set; } = new();

}
