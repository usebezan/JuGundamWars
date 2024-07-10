using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Core;

namespace Ju.GundamWars.Biz._.CoMobiles.Domain.Model;

public partial class CoMobileStatusSubject : GwObservableObject
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
    private int _CriticalDamage;
    [ObservableProperty]
    private int _Accuracy;
    [ObservableProperty]
    private int _Evasion;
    [ObservableProperty]
    private int _Mobility;


    public CoMobileStatusSubject Reset()
    {
        Hp = 0;
        BeamAttack = 0;
        PhysicalAttack = 0;
        BeamDefence = 0;
        PhysicalDefence = 0;
        CriticalDamage = 0;
        Accuracy = 0;
        Evasion = 0;
        Mobility = 0;
        return this;
    }

    public CoMobileStatusSubject Set(CoMobileStatusSubject status)
    {
        Hp = status.Hp;
        BeamAttack = status.BeamAttack;
        PhysicalAttack = status.PhysicalAttack;
        BeamDefence = status.BeamDefence;
        PhysicalDefence = status.PhysicalDefence;
        CriticalDamage = status.CriticalDamage;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Mobility = status.Mobility;
        return this;
    }

    public CoMobileStatusSubject Add(CoMobileStatusSubject status)
    {
        Hp += status.Hp;
        BeamAttack += status.BeamAttack;
        PhysicalAttack += status.PhysicalAttack;
        BeamDefence += status.BeamDefence;
        PhysicalDefence += status.PhysicalDefence;
        CriticalDamage += status.CriticalDamage;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Mobility += status.Mobility;
        return this;
    }

    public CoMobileStatusSubject AddWithBonus(CoMobileStatusSubject status, decimal multiplier)
    {
        Hp += status.Hp.Multiply(multiplier);
        BeamAttack += status.BeamAttack.Multiply(multiplier);
        PhysicalAttack += status.PhysicalAttack.Multiply(multiplier);
        BeamDefence += status.BeamDefence.Multiply(multiplier);
        PhysicalDefence += status.PhysicalDefence.Multiply(multiplier);
        CriticalDamage += status.CriticalDamage.Multiply(multiplier);
        Accuracy += status.Accuracy.Multiply(multiplier);
        Evasion += status.Evasion.Multiply(multiplier);
        Mobility += status.Mobility.Multiply(multiplier);
        return this;
    }

}
