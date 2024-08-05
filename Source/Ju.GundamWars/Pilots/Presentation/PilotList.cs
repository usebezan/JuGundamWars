using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Pilots.Domain;

internal partial class PilotList : BizListBase<Pilot>
{

    public PilotList(
        PilotInventory items,
        UnitInventory units,
        SerialInventory serials,
        PilotAbilityInventory pilotAbilities,
        PilotSkillInventory pilotSkills,
        TagInventory tags)
        : base(items, tags)
    {
        ForUnits = new(units);
        Serials = new(serials);
        PilotAbilities = new(pilotAbilities);
        PilotSkills = new(pilotSkills);

        IsIdle = true;
    }


    public ListCollectionView ForUnits { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView PilotAbilities { get; }
    public ListCollectionView PilotSkills { get; }

    [ObservableProperty]
    private Unit? _ForUnitFilter = null;
    [ObservableProperty]
    private Serial? _SerialFilter = null;
    [ObservableProperty]
    private PilotAbility? _PilotAbilityFilter = null;
    [ObservableProperty]
    private PilotSkill? _PilotSkillFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;
    [ObservableProperty]
    private bool _IsNotPinnedFilter = false;


    partial void OnForUnitFilterChanged(Unit? value) => Refresh();
    partial void OnSerialFilterChanged(Serial? value) => Refresh();
    partial void OnPilotAbilityFilterChanged(PilotAbility? value) => Refresh();
    partial void OnPilotSkillFilterChanged(PilotSkill? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();
    partial void OnIsNotPinnedFilterChanged(bool value) => Refresh();

    protected override bool FilterItem(object obj)
    {
        if (obj is not Pilot item) return false;
        if (ForUnitFilter != null && item.ForUnitType != ForUnitFilter.Type) return false;
        if (SerialFilter != null && item.SerialId != SerialFilter.Id) return false;
        if (PilotAbilityFilter != null && !item.PilotSlotAbilities.Any(i => i.PilotAbilityId == PilotAbilityFilter.Id)) return false;
        if (PilotSkillFilter != null && item.PilotSkillId != PilotSkillFilter.Id) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (HasMemoFilter && !item.HasMemo) return false;
        // TODO: if (HasNoMobileFilter && item.Mobile != null) return false;
        if (IsNotPinnedFilter && item.IsPinned) return false;
        return true;
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForPilot();
    }

    public override void FilterClear()
    {
        IsIdle = false;
        ForUnitFilter = null;
        SerialFilter = null;
        PilotAbilityFilter = null;
        PilotSkillFilter = null;
        TagFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsNotPinnedFilter = false;
        IsIdle = true;
        Refresh();
    }

}
