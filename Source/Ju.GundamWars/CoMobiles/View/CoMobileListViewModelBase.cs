using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal abstract partial class CoMobileListViewModelBase : BizListViewModelBase2<CoMobile, CoMobileViewModel, CoMobileEntryViewModel>
{

    public CoMobileListViewModelBase(
        CoMobileViewModel pageControllerViewModel,
        CoMobileEntryViewModel entryViewModel,
        CoMobileInventory itemInventory,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory)
        : base(pageControllerViewModel, entryViewModel, itemInventory, tagInventory)
    {
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };

        IsIdle = true;
    }


    public ListCollectionView Serials { get; }
    public ListCollectionView Roles { get; }

    [ObservableProperty]
    private Serial? _SerialFilter = null;
    [ObservableProperty]
    private Role? _RoleFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;
    [ObservableProperty]
    private bool _IsNotPinnedFilter = false;


    partial void OnSerialFilterChanged(Serial? value) => Refresh();
    partial void OnRoleFilterChanged(Role? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();
    partial void OnIsNotPinnedFilterChanged(bool value) => Refresh();

    private bool FilterRole(object obj)
    {
        if (obj is not Role item) return false;
        return item.Type.ForMobileSuit();
    }

    protected override bool FilterItem(object obj)
    {
        if (obj is not CoMobile item) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (SerialFilter != null && item.SerialId != SerialFilter.Id) return false;
        if (RoleFilter != null && item.RoleType != RoleFilter.Type) return false;
        if (HasMemoFilter && !item.HasMemo) return false;
        // TODO: if (HasNoMobileFilter && item.Mobile != null) return false;
        if (IsNotPinnedFilter && item.IsPinned) return false;
        return true;
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCoMobile();
    }

    protected override void ClearFilterCore()
    {
        IsIdle = false;
        TagFilter = null;
        SerialFilter = null;
        RoleFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsNotPinnedFilter = false;
        IsIdle = true;
        Refresh();
    }

}
