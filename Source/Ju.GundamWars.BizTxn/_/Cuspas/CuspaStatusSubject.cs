using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Core;

namespace Ju.GundamWars.BizTxn._.Cuspas;

public partial class CuspaStatusSubject : GwObservableObject
{

    [ObservableProperty]
    private int _Hp;
    [ObservableProperty]
    private int _BeamAttack;
    [ObservableProperty]
    private int _PhysicalAttack;
    [ObservableProperty]
    private int _BeamDefence;
    [ObservableProperty]
    private int _PhysicalDefence;
    [ObservableProperty]
    private int _CriticalRate;
    [ObservableProperty]
    private int _CriticalDamage;
    [ObservableProperty]
    private int _Accuracy;
    [ObservableProperty]
    private int _Evasion;
    [ObservableProperty]
    private int _Mobility;
    [ObservableProperty]
    private int _EnRecovery;


    public CuspaStatusSubject Reset()
    {
        Hp = 0;
        BeamAttack = 0;
        PhysicalAttack = 0;
        BeamDefence = 0;
        PhysicalDefence = 0;
        CriticalRate = 0;
        CriticalDamage = 0;
        Accuracy = 0;
        Evasion = 0;
        Mobility = 0;
        EnRecovery = 0;
        return this;
    }

    public CuspaStatusSubject Set(CuspaStatusSubject status)
    {
        Hp = status.Hp;
        BeamAttack = status.BeamAttack;
        PhysicalAttack = status.PhysicalAttack;
        BeamDefence = status.BeamDefence;
        PhysicalDefence = status.PhysicalDefence;
        CriticalRate = status.CriticalRate;
        CriticalDamage = status.CriticalDamage;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Mobility = status.Mobility;
        EnRecovery = status.EnRecovery;
        return this;
    }

    public CuspaStatusSubject Add(CuspaStatusSubject status)
    {
        Hp += status.Hp;
        BeamAttack += status.BeamAttack;
        PhysicalAttack += status.PhysicalAttack;
        BeamDefence += status.BeamDefence;
        PhysicalDefence += status.PhysicalDefence;
        CriticalRate += status.CriticalRate;
        CriticalDamage += status.CriticalDamage;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Mobility += status.Mobility;
        EnRecovery += status.EnRecovery;
        return this;
    }

    public CuspaStatusSubject AddWithBonus(CuspaStatusSubject status, decimal multiplier)
    {
        Hp += status.Hp.Multiply(multiplier);
        BeamAttack += status.BeamAttack.Multiply(multiplier);
        PhysicalAttack += status.PhysicalAttack.Multiply(multiplier);
        BeamDefence += status.BeamDefence.Multiply(multiplier);
        PhysicalDefence += status.PhysicalDefence.Multiply(multiplier);
        CriticalRate += status.CriticalRate.Multiply(multiplier);
        CriticalDamage += status.CriticalDamage.Multiply(multiplier);
        Accuracy += status.Accuracy.Multiply(multiplier);
        Evasion += status.Evasion.Multiply(multiplier);
        Mobility += status.Mobility.Multiply(multiplier);
        EnRecovery += status.EnRecovery.Multiply(multiplier);
        return this;
    }

}
