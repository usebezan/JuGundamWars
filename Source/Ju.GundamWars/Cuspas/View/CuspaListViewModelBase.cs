using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaListViewModelBase : BizListViewModelBase<Cuspa>
{

    public CuspaListViewModelBase(
        CuspaInventory items,
        UnitInventory units,
        CuspaKindInventory cuspaKinds,
        BoostStatusInventory boostStatuses,
        TagInventory tags)
        : base(items, tags)
    {
        ForUnits = new(units);
        CuspaKinds = new(cuspaKinds);
        BoostStatuses = new(boostStatuses);

        IsIdle = true;
    }


    public ListCollectionView ForUnits { get; }
    public ListCollectionView CuspaKinds { get; }
    public ListCollectionView BoostStatuses { get; }
    public bool IsFixedForUnitFilter { get; protected set; } = false;

    [ObservableProperty]
    private Unit? _ForUnitFilter = null;
    [ObservableProperty]
    private CuspaKind? _CuspaKindFilter = null;
    [ObservableProperty]
    private BoostStatus? _BoostStatusFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;


    partial void OnForUnitFilterChanged(Unit? value) => Refresh();
    partial void OnCuspaKindFilterChanged(CuspaKind? value) => Refresh();
    partial void OnBoostStatusFilterChanged(BoostStatus? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();

    protected override bool FilterItem(object obj)
    {
        if (obj is not Cuspa item) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (ForUnitFilter != null && item.ForUnitType != ForUnitFilter.Type) return false;
        if (CuspaKindFilter != null && item.CuspaKindType != CuspaKindFilter.Type) return false;
        if (BoostStatusFilter != null && item.BoostStatusType != BoostStatusFilter.Type) return false;
        if (HasMemoFilter && !item.HasMemo) return false;
        return true;
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCuspa();
    }

    public override void ClearFilter()
    {
        IsIdle = false;
        TagFilter = null;
        if (!IsFixedForUnitFilter)
        {
            ForUnitFilter = null;
        }
        CuspaKindFilter = null;
        BoostStatusFilter = null;
        HasMemoFilter = false;
        IsIdle = true;
        Refresh();
    }

}
