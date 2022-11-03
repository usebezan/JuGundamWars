using System;


namespace Ju.GundamWars.Models.Entities
{

    public class Pilot : BindableBase, IEntity
    {

        public Pilot()
        {
            Unit = 1;
            SlotRank1 = 1;
            SlotRank2 = 1;
            SlotRank3 = 1;
            Tag = 0;
        }


        public long Id { get => __Id; set => TrySetValue(ref __Id, value); }
        private long __Id;
        public string Name { get => __Name; set => TrySetValue(ref __Name, value); }
        private string __Name = null!;
        public byte Unit { get => __Unit; set => TrySetValue(ref __Unit, value); }
        private byte __Unit;
        public long SerialId { get => __SerialId; set => TrySetValue(ref __SerialId, value); }
        private long __SerialId;
        public long SkillId { get => __SkillId; set => TrySetValue(ref __SkillId, value); }
        private long __SkillId;
        public string? SkillText1 { get => __SkillText1; set => TrySetValue(ref __SkillText1, value); }
        private string? __SkillText1;
        public string? SkillText2 { get => __SkillText2; set => TrySetValue(ref __SkillText2, value); }
        private string? __SkillText2;

        public byte Grade { get => __Grade; set => TrySetValue(ref __Grade, value); }
        private byte __Grade;
        public byte Level { get => __Level; set => TrySetValue(ref __Level, value); }
        private byte __Level;
        public int Shooting { get => __Shooting; set => TrySetValue(ref __Shooting, value); }
        private int __Shooting;
        public int Melee { get => __Melee; set => TrySetValue(ref __Melee, value); }
        private int __Melee;
        public int Accuracy { get => __Accuracy; set => TrySetValue(ref __Accuracy, value); }
        private int __Accuracy;
        public int Evasion { get => __Evasion; set => TrySetValue(ref __Evasion, value); }
        private int __Evasion;
        public int Awakened { get => __Awakened; set => TrySetValue(ref __Awakened, value); }
        private int __Awakened;
        public int Defense { get => __Defense; set => TrySetValue(ref __Defense, value); }
        private int __Defense;

        public int PracticedShooting { get => __PracticedShooting; set => TrySetValue(ref __PracticedShooting, value); }
        private int __PracticedShooting;
        public int PracticedMelee { get => __PracticedMelee; set => TrySetValue(ref __PracticedMelee, value); }
        private int __PracticedMelee;
        public int PracticedAccuracy { get => __PracticedAccuracy; set => TrySetValue(ref __PracticedAccuracy, value); }
        private int __PracticedAccuracy;
        public int PracticedEvasion { get => __PracticedEvasion; set => TrySetValue(ref __PracticedEvasion, value); }
        private int __PracticedEvasion;
        public int PracticedAwakened { get => __PracticedAwakened; set => TrySetValue(ref __PracticedAwakened, value); }
        private int __PracticedAwakened;
        public int PracticedDefense { get => __PracticedDefense; set => TrySetValue(ref __PracticedDefense, value); }
        private int __PracticedDefense;
        public byte SlotRank1 { get => __SlotRank1; set => TrySetValue(ref __SlotRank1, value); }
        private byte __SlotRank1;
        public long? Ability1Id { get => __Ability1Id; set => TrySetValue(ref __Ability1Id, value); }
        private long? __Ability1Id;
        public byte SlotRank2 { get => __SlotRank2; set => TrySetValue(ref __SlotRank2, value); }
        private byte __SlotRank2;
        public long? Ability2Id { get => __Ability2Id; set => TrySetValue(ref __Ability2Id, value); }
        private long? __Ability2Id;
        public byte SlotRank3 { get => __SlotRank3; set => TrySetValue(ref __SlotRank3, value); }
        private byte __SlotRank3;
        public long? Ability3Id { get => __Ability3Id; set => TrySetValue(ref __Ability3Id, value); }
        private long? __Ability3Id;
        public byte Tag { get => __Tag; set => TrySetValue(ref __Tag, value); }
        private byte __Tag;
        public string? Memo { get => __Memo; set => TrySetValue(ref __Memo, value); }
        private string? __Memo;

        // define navigation properties:
        public Serial? Serial { get => __Serial; set => TrySetValue(ref __Serial, value); }
        private Serial? __Serial;
        public PilotSkill? Skill { get => __Skill; set => TrySetValue(ref __Skill, value); }
        private PilotSkill? __Skill;

        public PilotAbility? Ability1 { get => __Ability1; set => TrySetValue(ref __Ability1, value); }
        private PilotAbility? __Ability1;
        public PilotAbility? Ability2 { get => __Ability2; set => TrySetValue(ref __Ability2, value); }
        private PilotAbility? __Ability2;
        public PilotAbility? Ability3 { get => __Ability3; set => TrySetValue(ref __Ability3, value); }
        private PilotAbility? __Ability3;

    }

}
