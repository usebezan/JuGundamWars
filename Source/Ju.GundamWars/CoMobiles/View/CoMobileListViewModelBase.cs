using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share._TODO.Categories.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.ComponentModel;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal abstract partial class CoMobileListViewModelBase : ModelBase
{

    public CoMobileListViewModelBase(
        CoMobileInventory coMobiles,
        SerialInventory serials,
        TagInventory tags)
    {
        IsIdle = false;

        CoMobiles = coMobiles;
        ItemsView = new(coMobiles) { Filter = Filter, };
        Serials = new(serials);
        Tags = new(tags) { Filter = FilterTag, };

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));

        IsIdle = true;
    }


    protected bool IsIdle { get; set; }
    protected CoMobileInventory CoMobiles { get; set; }

    public ListCollectionView ItemsView { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView Tags { get; }

    [ObservableProperty]
    private Serial? _SerialFilter = null;
    [ObservableProperty]
    private Tag? _TagFilter = null;
    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;
    [ObservableProperty]
    private bool _IsNotPinnedFilter = false;


    partial void OnSerialFilterChanged(Serial? value) => Refresh();
    partial void OnTagFilterChanged(Tag? value) => Refresh();
    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();
    partial void OnIsNotPinnedFilterChanged(bool value) => Refresh();

    private bool Filter(object obj)
    {
        if (obj is not CoMobile item) return false;
        if (SerialFilter != null && item.Serial?.Id != SerialFilter.Id) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (HasMemoFilter && !item.HasMemo) return false;
        //if (HasNoMobileFilter && item.Mobile != null) return false;
        if (IsNotPinnedFilter && item.IsPinned) return false;
        return true;
    }

    private bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCoMobile();
    }

    protected virtual void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
    }

    [RelayCommand]
    private void FilterClear()
    {
        IsIdle = false;
        SerialFilter = null;
        TagFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsNotPinnedFilter = false;
        IsIdle = true;
        Refresh();
    }

}
