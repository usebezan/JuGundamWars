using Ju.GundamWars.Core.Ju.GundamWars.Masters.AceImpls;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Grades;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.MobileKinds;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Positions;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Roles;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Terrains;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Entities;

public class Mobile : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryType Category { get; set; } = CategoryType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public MobileKindType Kind { get; set; } = MobileKindType.Normal;
    public RoleType Role { get; set; } = RoleType.Defensive;
    public PositionType DefaultPosition { get; set; } = PositionType.Front;
    public GradeType InitialGrade { get; set; } = GradeType.Grade4;
    public TerrainType Terrain1 { get; set; } = TerrainType.Grade1;
    public TerrainType Terrain2 { get; set; } = TerrainType.Grade1;
    public TerrainType Terrain3 { get; set; } = TerrainType.Grade1;
    public byte Blueprint { get; set; }
    public byte Proof { get; set; }
    public GradeType Grade { get; set; } = GradeType.Grade4;
    public byte Level { get; set; } = 50;
    public byte Version { get; set; } = 14;
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
    public int SuperEnRecovery { get; set; }
    public int AceEnRecovery { get; set; }
    public int RemodeledHp { get; set; }
    public int RemodeledBeamAttack { get; set; }
    public int RemodeledPhysicalAttack { get; set; }
    public int RemodeledBeamDefence { get; set; }
    public int RemodeledPhysicalDefence { get; set; }
    public int RemodeledCriticalRate { get; set; }
    public int RemodeledCriticalDamage { get; set; }
    public int RemodeledAccuracy { get; set; }
    public int RemodeledEvasion { get; set; }
    public int RemodeledMobility { get; set; }
    public int RemodeledEnRecovery { get; set; }
    public AceImplType HasAce { get; set; } = AceImplType.Unimplemented;
    public byte SuperEnGrade { get; set; }
    public byte AceEnGrade { get; set; }
    public int EnTank { get; set; }
    public int? SSkillId1 { get; set; }
    public string? SSkillText1 { get; set; }
    public int? SSkillId2 { get; set; }
    public string? SSkillText2 { get; set; }
    public byte SupportProof { get; set; }
    public byte SupportUnlock { get; set; } = 1;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    public List<MobilePairMap> PairMaps { get; set; } = [];
    public List<MobileSubSerialMap> SubSerialMaps { get; set; } = [];
    public List<MobileTagMap> TagMaps { get; set; } = [];
    public List<MobilePilotMap> PilotMaps { get; set; } = [];
    public List<MobileCuspa> Cuspas { get; set; } = [];
    public List<MobileSupport> Supports { get; set; } = [];
    public List<MobileCoMobile> CoMobiles { get; set; } = [];

}
