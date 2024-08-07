using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModelBase : BizListViewModelBase<CoMobile>
{

    public CoMobileListViewModelBase(
        CoMobileInventory items,
        SerialInventory serials,
        TagInventory tags)
        : base(items, tags)
    {
        Serials = new(serials);

        IsIdle = true;
    }


    public ListCollectionView Serials { get; }

    [ObservableProperty]
    private Serial? _SerialFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;
    [ObservableProperty]
    private bool _IsNotPinnedFilter = false;


    partial void OnSerialFilterChanged(Serial? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();
    partial void OnIsNotPinnedFilterChanged(bool value) => Refresh();

    protected override bool FilterItem(object obj)
    {
        if (obj is not CoMobile item) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (SerialFilter != null && item.SerialId != SerialFilter.Id) return false;
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

    public override void ClearFilter()
    {
        IsIdle = false;
        TagFilter = null;
        SerialFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsNotPinnedFilter = false;
        IsIdle = true;
        Refresh();
    }

}
