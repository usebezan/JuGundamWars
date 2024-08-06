using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.Windows.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ju.GundamWars.Supports.Domain;

internal partial class SupportList : BizListBase<Support>
{

    public SupportList(
        SupportInventory items,
        UnitInventory units,
        SerialInventory serials,
        BoostStatusInventory boostStatuses,
        SupportSlotInventory supportSlots,
        SupportBadgeInventory supportBadges,
        TagInventory tags)
        : base(items, tags)
    {
        ForUnits = new(units);
        Serials = new(serials);
        BoostStatuses = new(boostStatuses);
        SupportSlots = new(supportSlots);
        SupportBadges = new(supportBadges);

        SupportSlots.GroupDescriptions.Add(new PropertyGroupDescription("TargetText"));
        SupportBadges.GroupDescriptions.Add(new PropertyGroupDescription("TargetText"));

        IsIdle = true;
    }


    public ListCollectionView ForUnits { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView BoostStatuses { get; }
    public ListCollectionView SupportSlots { get; }
    public ListCollectionView SupportBadges { get; }

    [ObservableProperty]
    private Unit? _ForUnitFilter = null;
    [ObservableProperty]
    private Serial? _SerialFilter = null;
    [ObservableProperty]
    private BoostStatus? _BoostStatusFilter = null;
    [ObservableProperty]
    private SupportSlot? _SupportSlotFilter = null;
    [ObservableProperty]
    private SupportBadge? _SupportBadgeFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;
    [ObservableProperty]
    private bool _IsNotPinnedFilter = false;


    partial void OnForUnitFilterChanged(Unit? value) => Refresh();
    partial void OnSerialFilterChanged(Serial? value) => Refresh();
    partial void OnBoostStatusFilterChanged(BoostStatus? value) => Refresh();
    partial void OnSupportSlotFilterChanged(SupportSlot? value) => Refresh();
    partial void OnSupportBadgeFilterChanged(SupportBadge? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();
    partial void OnIsNotPinnedFilterChanged(bool value) => Refresh();

    protected override bool FilterItem(object obj)
    {
        if (obj is not Support item) return false;
        if (ForUnitFilter != null && item.ForUnitType != ForUnitFilter.Type) return false;
        if (SerialFilter != null && item.SerialId != SerialFilter.Id) return false;
        if (BoostStatusFilter != null && !item.SupportSlotBadges.Any(i => i.BoostStatusType == BoostStatusFilter.Type)) return false;
        if (SupportSlotFilter != null && !item.SupportSlotBadges.Any(i => i.SupportSlotId == SupportSlotFilter.Id)) return false;
        if (SupportBadgeFilter != null && !item.SupportSlotBadges.Any(i => i.SupportBadgeId == SupportBadgeFilter.Id)) return false;
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
        return item.TagGroupType.ForSupport();
    }

    public override void FilterClear()
    {
        IsIdle = false;
        ForUnitFilter = null;
        SerialFilter = null;
        BoostStatusFilter = null;
        SupportSlotFilter = null;
        SupportBadgeFilter = null;
        TagFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsNotPinnedFilter = false;
        IsIdle = true;
        Refresh();
    }

}
