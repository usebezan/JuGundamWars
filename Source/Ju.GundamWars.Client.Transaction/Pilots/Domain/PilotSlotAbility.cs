using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Client.Pilots.Domain;

public partial class PilotSlotAbility : ModelBase, IPilotSlotAbility
{

    #region Primitives

    [ObservableProperty]
    private int _PilotId;
    [ObservableProperty]
    private byte _Seq;
    [ObservableProperty]
    private byte _SlotRank;
    [ObservableProperty]
    private int _PilotAbilityId;

    #endregion

    #region Navigations

    [ObservableProperty]
    private PilotAbility? _PilotAbility;

    #endregion


    partial void OnPilotAbilityChanged(PilotAbility? value)
    {
        // Pilot で購読
        OnPropertyChanged("Ability");
    }

}
