using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Share;

public static class TransactionShareExtension
{

    public static T Set<T>(this T self, ICoMobileStatus status)
        where T : ICoMobileStatus
    {
        self.Hp = status.Hp;
        self.BeamAttack = status.BeamAttack;
        self.PhysicalAttack = status.PhysicalAttack;
        self.BeamDefence = status.BeamDefence;
        self.PhysicalDefence = status.PhysicalDefence;
        self.CriticalDamage = status.CriticalDamage;
        self.Accuracy = status.Accuracy;
        self.Evasion = status.Evasion;
        self.Mobility = status.Mobility;
        return self;
    }

}
