using System;


namespace Ju.GundamWars
{

    [Flags]
    public enum HolderType : int
    {
        MobileSuitSkill = 1,
        MobileSuitAbility = MobileSuitSkill << 1,
        MobileArmorSkill = MobileSuitSkill << 2,
        MobileArmorAbility = MobileSuitSkill << 3,
        BattleshipSkill = MobileSuitSkill << 4,
        PilotSkill = MobileSuitSkill << 5,
        CrewSkill = MobileSuitSkill << 6,
        Unknown = 255,
    }


    public static class HolderTypeExtension
    {

        public static HolderType ToHolderType(this int self)
        {
            try { return (HolderType)self; } catch { return HolderType.Unknown; }
        }

        public static int ToValue(this HolderType self) =>
            (int)self;

    }

}
