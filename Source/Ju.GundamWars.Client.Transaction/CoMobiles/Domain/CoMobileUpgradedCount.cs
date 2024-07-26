using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Client.CoMobiles.Domain;

public partial class CoMobileUpgradedCount : ModelBase, ICoMobileUpgradedCount
{

    [ObservableProperty, NotifyPropertyChangedFor(nameof(HpText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _Hp;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BeamAttackText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _BeamAttack;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(PhysicalAttackText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _PhysicalAttack;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BeamDefenceText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _BeamDefence;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(PhysicalDefenceText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _PhysicalDefence;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CriticalDamageText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _CriticalDamage;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(AccuracyText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _Accuracy;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(EvasionText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _Evasion;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(MobilityText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _Mobility;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(StartupText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _Startup;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(SuperMoveText)), NotifyPropertyChangedFor(nameof(Total))]
    private int _SuperMove;

    public string HpText => GetText(Hp);
    public string BeamAttackText => GetText(BeamAttack);
    public string PhysicalAttackText => GetText(PhysicalAttack);
    public string BeamDefenceText => GetText(BeamDefence);
    public string PhysicalDefenceText => GetText(PhysicalDefence);
    public string CriticalDamageText => GetText(CriticalDamage);
    public string AccuracyText => GetText(Accuracy);
    public string EvasionText => GetText(Evasion);
    public string MobilityText => GetText(Mobility);
    public string StartupText => GetText(Startup);
    public string SuperMoveText => GetText(SuperMove);
    public int Total => Hp + BeamAttack + PhysicalAttack + BeamDefence + PhysicalDefence + CriticalDamage + Accuracy + Evasion + Mobility + Startup + SuperMove;


    public CoMobileUpgradedCount Reset()
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
        Startup = 0;
        SuperMove = 0;
        return this;
    }

    private string GetText(int value) =>
        "".PadLeft(value, '■').PadRight(5, '□')[..5];

}
