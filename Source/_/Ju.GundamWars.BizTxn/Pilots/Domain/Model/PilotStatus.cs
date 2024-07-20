using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Model;

public partial class PilotStatus : ModelBase
{

    [ObservableProperty]
    private int _Shooting;
    [ObservableProperty]
    private int _Melee;
    [ObservableProperty]
    private int _Accuracy;
    [ObservableProperty]
    private int _Evasion;
    [ObservableProperty]
    private int _Awakened;
    [ObservableProperty]
    private int _Defense;


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

    public PilotStatus Set(PilotStatus status)
    {
        Shooting = status.Shooting;
        Melee = status.Melee;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Awakened = status.Awakened;
        Defense = status.Defense;
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

    public PilotStatus Add(BoostStatusType type, decimal value) =>
        Add(type, decimal.ToInt32(value));

    public int Total() =>
        Shooting + Melee + Accuracy + Evasion + Awakened + Defense;

}
