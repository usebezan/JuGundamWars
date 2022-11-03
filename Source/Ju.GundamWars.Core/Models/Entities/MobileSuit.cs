using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ju.GundamWars.Models.Entities
{

    public class MobileSuit : BindableBase, IEntity
    {

        public MobileSuit()
        {
            Type1 = 1;
            Type2 = 0;
            InitialGrade = 1;
            Role = 1;
            Tag = 0;
        }


        public long Id { get => __Id; set => TrySetValue(ref __Id, value); }
        private long __Id;
        public string Name { get => __Name; set => TrySetValue(ref __Name, value); }
        private string __Name = null!;
        public long SerialId { get => __SerialId; set => TrySetValue(ref __SerialId, value); }
        private long __SerialId;
        public long? SubSerial1Id { get => __SubSerial1Id; set => TrySetValue(ref __SubSerial1Id, value); }
        private long? __SubSerial1Id;
        public long? SubSerial2Id { get => __SubSerial2Id; set => TrySetValue(ref __SubSerial2Id, value); }
        private long? __SubSerial2Id;
        public long? SubSerial3Id { get => __SubSerial3Id; set => TrySetValue(ref __SubSerial3Id, value); }
        private long? __SubSerial3Id;
        public long? SubSerial4Id { get => __SubSerial4Id; set => TrySetValue(ref __SubSerial4Id, value); }
        private long? __SubSerial4Id;
        public byte Type1 { get => __Type1; set => TrySetValue(ref __Type1, value); }
        private byte __Type1;
        public byte Type2 { get => __Type2; set => TrySetValue(ref __Type2, value); }
        private byte __Type2;
        public byte DefaultPosition { get => __DefaultPosition; set => TrySetValue(ref __DefaultPosition, value); }
        private byte __DefaultPosition;
        public byte InitialGrade { get => __InitialGrade; set => TrySetValue(ref __InitialGrade, value); }
        private byte __InitialGrade;
        public byte Role { get => __Role; set => TrySetValue(ref __Role, value); }
        private byte __Role;
        public byte Terrain1 { get => __Terrain1; set => TrySetValue(ref __Terrain1, value); }
        private byte __Terrain1;
        public byte Terrain2 { get => __Terrain2; set => TrySetValue(ref __Terrain2, value); }
        private byte __Terrain2;
        public byte Terrain3 { get => __Terrain3; set => TrySetValue(ref __Terrain3, value); }
        private byte __Terrain3;

        public byte Blueprint { get => __Blueprint; set => TrySetValue(ref __Blueprint, value); }
        private byte __Blueprint;
        public byte Certificate { get => __Certificate; set => TrySetValue(ref __Certificate, value); }
        private byte __Certificate;
        public byte Grade { get => __Grade; set => TrySetValue(ref __Grade, value); }
        private byte __Grade;
        public byte Level { get => __Level; set => TrySetValue(ref __Level, value); }
        private byte __Level;
        public int Hp { get => __Hp; set => TrySetValue(ref __Hp, value); }
        private int __Hp;
        public int BeamAttack { get => __BeamAttack; set => TrySetValue(ref __BeamAttack, value); }
        private int __BeamAttack;
        public int PhysicalAttack { get => __PhysicalAttack; set => TrySetValue(ref __PhysicalAttack, value); }
        private int __PhysicalAttack;
        public int BeamDefence { get => __BeamDefence; set => TrySetValue(ref __BeamDefence, value); }
        private int __BeamDefence;
        public int PhysicalDefence { get => __PhysicalDefence; set => TrySetValue(ref __PhysicalDefence, value); }
        private int __PhysicalDefence;
        public int CriticalRate { get => __CriticalRate; set => TrySetValue(ref __CriticalRate, value); }
        private int __CriticalRate;
        public int CriticalDamage { get => __CriticalDamage; set => TrySetValue(ref __CriticalDamage, value); }
        private int __CriticalDamage;
        public int Accuracy { get => __Accuracy; set => TrySetValue(ref __Accuracy, value); }
        private int __Accuracy;
        public int Evasion { get => __Evasion; set => TrySetValue(ref __Evasion, value); }
        private int __Evasion;
        public int Mobility { get => __Mobility; set => TrySetValue(ref __Mobility, value); }
        private int __Mobility;
        public int SuperEnRecovery { get => __SuperEnRecovery; set => TrySetValue(ref __SuperEnRecovery, value); }
        private int __SuperEnRecovery;
        public int AceEnRecovery { get => __AceEnRecovery; set => TrySetValue(ref __AceEnRecovery, value); }
        private int __AceEnRecovery;
        public int RemodelingHp { get => __RemodelingHp; set => TrySetValue(ref __RemodelingHp, value); }
        private int __RemodelingHp;
        public int RemodelingBeamAttack { get => __RemodelingBeamAttack; set => TrySetValue(ref __RemodelingBeamAttack, value); }
        private int __RemodelingBeamAttack;
        public int RemodelingPhysicalAttack { get => __RemodelingPhysicalAttack; set => TrySetValue(ref __RemodelingPhysicalAttack, value); }
        private int __RemodelingPhysicalAttack;
        public int RemodelingBeamDefence { get => __RemodelingBeamDefence; set => TrySetValue(ref __RemodelingBeamDefence, value); }
        private int __RemodelingBeamDefence;
        public int RemodelingPhysicalDefence { get => __RemodelingPhysicalDefence; set => TrySetValue(ref __RemodelingPhysicalDefence, value); }
        private int __RemodelingPhysicalDefence;
        public int RemodelingCriticalRate { get => __RemodelingCriticalRate; set => TrySetValue(ref __RemodelingCriticalRate, value); }
        private int __RemodelingCriticalRate;
        public int RemodelingCriticalDamage { get => __RemodelingCriticalDamage; set => TrySetValue(ref __RemodelingCriticalDamage, value); }
        private int __RemodelingCriticalDamage;
        public int RemodelingAccuracy { get => __RemodelingAccuracy; set => TrySetValue(ref __RemodelingAccuracy, value); }
        private int __RemodelingAccuracy;
        public int RemodelingEvasion { get => __RemodelingEvasion; set => TrySetValue(ref __RemodelingEvasion, value); }
        private int __RemodelingEvasion;
        public int RemodelingMobility { get => __RemodelingMobility; set => TrySetValue(ref __RemodelingMobility, value); }
        private int __RemodelingMobility;
        public int RemodelingEnRecovery { get => __RemodelingEnRecovery; set => TrySetValue(ref __RemodelingEnRecovery, value); }
        private int __RemodelingEnRecovery;

        public int CustomHp { get => __CustomHp; set => TrySetValue(ref __CustomHp, value); }
        private int __CustomHp;
        public int CustomBeamAttack { get => __CustomBeamAttack; set => TrySetValue(ref __CustomBeamAttack, value); }
        private int __CustomBeamAttack;
        public int CustomPhysicalAttack { get => __CustomPhysicalAttack; set => TrySetValue(ref __CustomPhysicalAttack, value); }
        private int __CustomPhysicalAttack;
        public int CustomBeamDefence { get => __CustomBeamDefence; set => TrySetValue(ref __CustomBeamDefence, value); }
        private int __CustomBeamDefence;
        public int CustomPhysicalDefence { get => __CustomPhysicalDefence; set => TrySetValue(ref __CustomPhysicalDefence, value); }
        private int __CustomPhysicalDefence;
        public int CustomCriticalRate { get => __CustomCriticalRate; set => TrySetValue(ref __CustomCriticalRate, value); }
        private int __CustomCriticalRate;
        public int CustomCriticalDamage { get => __CustomCriticalDamage; set => TrySetValue(ref __CustomCriticalDamage, value); }
        private int __CustomCriticalDamage;
        public int CustomAccuracy { get => __CustomAccuracy; set => TrySetValue(ref __CustomAccuracy, value); }
        private int __CustomAccuracy;
        public int CustomEvasion { get => __CustomEvasion; set => TrySetValue(ref __CustomEvasion, value); }
        private int __CustomEvasion;
        public int CustomMobility { get => __CustomMobility; set => TrySetValue(ref __CustomMobility, value); }
        private int __CustomMobility;
        public int CustomEnRecovery { get => __CustomEnRecovery; set => TrySetValue(ref __CustomEnRecovery, value); }
        private int __CustomEnRecovery;
        public string? CustomText { get => __CustomText; set => TrySetValue(ref __CustomText, value); }
        private string? __CustomText;
        public long? PilotId { get => __PilotId; set => TrySetValue(ref __PilotId, value); }
        private long? __PilotId;
        public long? Support1Id { get => __Support1Id; set => TrySetValue(ref __Support1Id, value); }
        private long? __Support1Id;
        public long? Support2Id { get => __Support2Id; set => TrySetValue(ref __Support2Id, value); }
        private long? __Support2Id;
        public long? Support3Id { get => __Support3Id; set => TrySetValue(ref __Support3Id, value); }
        private long? __Support3Id;
        public long? Support4Id { get => __Support4Id; set => TrySetValue(ref __Support4Id, value); }
        private long? __Support4Id;
        public long? SAbility1Id { get => __SAbility1Id; set => TrySetValue(ref __SAbility1Id, value); }
        private long? __SAbility1Id;
        public long? SAbility2Id { get => __SAbility2Id; set => TrySetValue(ref __SAbility2Id, value); }
        private long? __SAbility2Id;
        public long? SAbility3Id { get => __SAbility3Id; set => TrySetValue(ref __SAbility3Id, value); }
        private long? __SAbility3Id;
        public long? SAbility4Id { get => __SAbility4Id; set => TrySetValue(ref __SAbility4Id, value); }
        private long? __SAbility4Id;
        public byte Tag { get => __Tag; set => TrySetValue(ref __Tag, value); }
        private byte __Tag;
        public string? Memo { get => __Memo; set => TrySetValue(ref __Memo, value); }
        private string? __Memo;

        // define navigation properties:
        public Serial? Serial { get => __Serial; set => TrySetValue(ref __Serial, value); }
        private Serial? __Serial;
        public Serial? SubSerial1 { get => __SubSerial1; set => TrySetValue(ref __SubSerial1, value); }
        private Serial? __SubSerial1;
        public Serial? SubSerial2 { get => __SubSerial2; set => TrySetValue(ref __SubSerial2, value); }
        private Serial? __SubSerial2;
        public Serial? SubSerial3 { get => __SubSerial3; set => TrySetValue(ref __SubSerial3, value); }
        private Serial? __SubSerial3;
        public Serial? SubSerial4 { get => __SubSerial4; set => TrySetValue(ref __SubSerial4, value); }
        private Serial? __SubSerial4;

        public Pilot? Pilot { get => __Pilot; set => TrySetValue(ref __Pilot, value); }
        private Pilot? __Pilot;
        public Support? Support1 { get => __Support1; set => TrySetValue(ref __Support1, value); }
        private Support? __Support1;
        public Support? Support2 { get => __Support2; set => TrySetValue(ref __Support2, value); }
        private Support? __Support2;
        public Support? Support3 { get => __Support3; set => TrySetValue(ref __Support3, value); }
        private Support? __Support3;
        public Support? Support4 { get => __Support4; set => TrySetValue(ref __Support4, value); }
        private Support? __Support4;
        public UnitSAbility? SAbility1 { get => __SAbility1; set => TrySetValue(ref __SAbility1, value); }
        private UnitSAbility? __SAbility1;
        public UnitSAbility? SAbility2 { get => __SAbility2; set => TrySetValue(ref __SAbility2, value); }
        private UnitSAbility? __SAbility2;
        public UnitSAbility? SAbility3 { get => __SAbility3; set => TrySetValue(ref __SAbility3, value); }
        private UnitSAbility? __SAbility3;
        public UnitSAbility? SAbility4 { get => __SAbility4; set => TrySetValue(ref __SAbility4, value); }
        private UnitSAbility? __SAbility4;

        [NotMapped]
        public MobileSuitType1 MobileSuitType1 => Type1.ToMobileSuitType1();

        [NotMapped]
        public MobileSuitType2 MobileSuitType2 => Type2.ToMobileSuitType2();

        [NotMapped]
        public MobileSuitRoleType RoleType => Role.ToMobileSuitRoleType();

    }

}
