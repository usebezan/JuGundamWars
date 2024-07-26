using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Share.CoMobiles;

public static class CoMobileShareExtension
{

    public static T Set<T>(this T self, ICoMobileStatus src)
        where T : ICoMobileStatus
    {
        self.Hp = src.Hp;
        self.BeamAttack = src.BeamAttack;
        self.PhysicalAttack = src.PhysicalAttack;
        self.BeamDefence = src.BeamDefence;
        self.PhysicalDefence = src.PhysicalDefence;
        self.CriticalDamage = src.CriticalDamage;
        self.Accuracy = src.Accuracy;
        self.Evasion = src.Evasion;
        self.Mobility = src.Mobility;
        return self;
    }

    public static T Set<T>(this T self, ICoMobileUpgradedCount src)
        where T : ICoMobileUpgradedCount
    {
        self.Hp = src.Hp;
        self.BeamAttack = src.BeamAttack;
        self.PhysicalAttack = src.PhysicalAttack;
        self.BeamDefence = src.BeamDefence;
        self.PhysicalDefence = src.PhysicalDefence;
        self.CriticalDamage = src.CriticalDamage;
        self.Accuracy = src.Accuracy;
        self.Evasion = src.Evasion;
        self.Mobility = src.Mobility;
        self.Startup = src.Startup;
        self.SuperMove = src.SuperMove;
        return self;
    }

}
