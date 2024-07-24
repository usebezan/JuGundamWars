using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Client.CoMobiles.Domain;

public partial class CoMobileStatus : ModelBase
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


    public CoMobileStatus Reset()
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

    public CoMobileStatus Set(CoMobileStatus status)
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

    public CoMobileStatus Add(CoMobileStatus status)
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

    public CoMobileStatus AddWithBonus(CoMobileStatus status, int value)
    {
        Hp += status.Hp.Multiply1k(value);
        BeamAttack += status.BeamAttack.Multiply1k(value);
        PhysicalAttack += status.PhysicalAttack.Multiply1k(value);
        BeamDefence += status.BeamDefence.Multiply1k(value);
        PhysicalDefence += status.PhysicalDefence.Multiply1k(value);
        CriticalDamage += status.CriticalDamage.Multiply1k(value);
        Accuracy += status.Accuracy.Multiply1k(value);
        Evasion += status.Evasion.Multiply1k(value);
        Mobility += status.Mobility.Multiply1k(value);
        return this;
    }

}
