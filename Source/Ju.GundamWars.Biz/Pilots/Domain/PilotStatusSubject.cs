using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizMaster.PilotStatuses;
using Ju.GundamWars.Core;

namespace Ju.GundamWars.Domain.Pilots;

public partial class PilotStatusSubject : GwObservableObject
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


    public PilotStatusSubject Reset()
    {
        Shooting = 0;
        Melee = 0;
        Accuracy = 0;
        Evasion = 0;
        Awakened = 0;
        Defense = 0;
        return this;
    }

    public PilotStatusSubject Set(PilotStatusSubject status)
    {
        Shooting = status.Shooting;
        Melee = status.Melee;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Awakened = status.Awakened;
        Defense = status.Defense;
        return this;
    }

    public PilotStatusSubject Add(PilotStatusSubject status)
    {
        Shooting += status.Shooting;
        Melee += status.Melee;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Awakened += status.Awakened;
        Defense += status.Defense;
        return this;
    }

    public PilotStatusSubject Add(PilotStatusType type, int value)
    {
        switch (type)
        {
            case PilotStatusType.Shooting:
                Shooting += value;
                break;
            case PilotStatusType.Melee:
                Melee += value;
                break;
            case PilotStatusType.Accuracy:
                Accuracy += value;
                break;
            case PilotStatusType.Evasion:
                Evasion += value;
                break;
            case PilotStatusType.Awakened:
                Awakened += value;
                break;
            case PilotStatusType.Defense:
                Defense += value;
                break;
        }
        return this;
    }

    public PilotStatusSubject Add(PilotStatusType type, decimal value) =>
        Add(type, decimal.ToInt32(value));

    public int Total() =>
        Shooting + Melee + Accuracy + Evasion + Awakened + Defense;

}
