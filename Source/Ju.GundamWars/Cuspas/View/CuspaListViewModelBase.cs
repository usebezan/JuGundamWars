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

internal abstract partial class CuspaListViewModelBase : BizListViewModelBase2<Cuspa>
{

    public CuspaListViewModelBase(
        CuspaInventory itemInventory,
        UnitInventory unitInventory,
        CuspaKindInventory cuspaKindInventory,
        BoostStatusInventory boostStatusInventory,
        TagInventory tagInventory,
        ViewState viewState)
        : base(itemInventory, tagInventory, viewState)
    {
        IsFixedForUnitFilter = false;

        ForUnits = new(unitInventory) { Filter = FilterForUnit, };
        CuspaKinds = new(cuspaKindInventory);
        BoostStatuses = new(boostStatusInventory) { Filter = FilterBoostStatus, };
    }


    protected bool IsFixedForUnitFilter { get; set; }

    public ListCollectionView ForUnits { get; }
    public ListCollectionView CuspaKinds { get; }
    public ListCollectionView BoostStatuses { get; }

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

    private bool FilterForUnit(object obj)
    {
        if (obj is not Unit item) return false;
        return item.Type.ForCuspa();
    }

    private bool FilterBoostStatus(object obj)
    {
        if (obj is not BoostStatus item) return false;
        return item.Type.ForCuspa();
    }

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

    protected override void ClearFilterCore()
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
