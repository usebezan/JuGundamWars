using System;


namespace Ju.GundamWars
{

    public enum UnitType : byte
    {
        MobileSuit = 1,
        MobileArmor,
        Battleship,
        Unknown = 255,
    }


    public static class UnitTypeExtension
    {

        public static UnitType ToUnitType(this byte self)
        {
            try { return (UnitType)self; } catch { return UnitType.Unknown; }
        }

        public static byte ToValue(this UnitType self) =>
            (byte)self;

        public static string ToText(this UnitType self) =>
            self switch
            {
                UnitType.MobileSuit => "MS",
                UnitType.MobileArmor => "MA",
                UnitType.Battleship => "BS",
                _ => "不明",
            };

        public static string ToIconKind(this UnitType self) =>
            self switch
            {
                UnitType.MobileSuit => "Robot",
                UnitType.MobileArmor => "CarLiftedPickup",
                UnitType.Battleship => "SailBoat",
                _ => "Help",
            };

    }

}
