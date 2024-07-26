using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Share.Cuspas;

public static class CuspaShareExtension
{

    public static T Set<T>(this T self, ICuspaStatus src)
        where T : ICuspaStatus
    {
        self.Hp = src.Hp;
        self.BeamAttack = src.BeamAttack;
        self.PhysicalAttack = src.PhysicalAttack;
        self.BeamDefence = src.BeamDefence;
        self.PhysicalDefence = src.PhysicalDefence;
        self.CriticalRate = src.CriticalRate;
        self.CriticalDamage = src.CriticalDamage;
        self.Accuracy = src.Accuracy;
        self.Evasion = src.Evasion;
        self.Mobility = src.Mobility;
        self.EnRecovery = src.EnRecovery;
        return self;
    }

}
