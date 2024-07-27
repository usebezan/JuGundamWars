using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Client.Pilots.Domain;

public partial class PilotStatus : ModelBase, IPilotStatus
{

    #region Primitives

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Shooting;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Melee;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Accuracy;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Evasion;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Awakened;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
    private int _Defense;

    #endregion

    #region Extensions

    public int Total => Shooting + Melee + Accuracy + Evasion + Awakened + Defense;

    #endregion


    public PilotStatus Reset()
    {
        Shooting = 0;
        Melee = 0;
        Accuracy = 0;
        Evasion = 0;
        Awakened = 0;
        Defense = 0;
        return this;
    }

    public PilotStatus Add(PilotStatus status)
    {
        Shooting += status.Shooting;
        Melee += status.Melee;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Awakened += status.Awakened;
        Defense += status.Defense;
        return this;
    }

    public PilotStatus Add(BoostStatusType type, int value)
    {
        switch (type)
        {
            case BoostStatusType.Shooting:
                Shooting += value;
                break;
            case BoostStatusType.Melee:
                Melee += value;
                break;
            case BoostStatusType.Accuracy:
                Accuracy += value;
                break;
            case BoostStatusType.Evasion:
                Evasion += value;
                break;
            case BoostStatusType.Awakened:
                Awakened += value;
                break;
            case BoostStatusType.Defense:
                Defense += value;
                break;
        }
        return this;
    }

}
