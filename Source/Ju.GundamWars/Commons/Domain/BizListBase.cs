using CommunityToolkit.Mvvm.ComponentModel;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.Domain;

internal abstract partial class BizListBase<T> : ModelBase, IBizList
    where T : BizBase
{

    public BizListBase(ObservableItemPropertyChangedCollection<T> items, TagInventory tags)
    {
        IsIdle = false;

        Items = items;
        ItemsView = new(items) { Filter = FilterItem, };
        Tags = new(tags) { Filter = FilterTag, };

        Items.ItemPropertyChanged.Where(e => e.PropertyName == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
    }


    protected bool IsIdle { get; set; }

    public ObservableItemPropertyChangedCollection<T> Items { get; }
    public ListCollectionView ItemsView { get; }
    public ListCollectionView Tags { get; }
    public bool IsCountable { get; set; }

    [ObservableProperty]
    private Tag? _TagFilter = null;

    [ObservableProperty]
    private int _CheckedCount = 0;
    [ObservableProperty]
    private int _FilteredCheckedCount = 0;


    partial void OnTagFilterChanged(Tag? value) => Refresh();

    private void WhenIsCheckedChanged(PropertyChangedEventArgs e) => SetCount();

    protected abstract bool FilterItem(object obj);
    protected abstract bool FilterTag(object obj);

    protected void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
        SetCount();
    }

    public abstract void FilterClear();

    public void SetCount()
    {
        if (!IsCountable) return;
        CheckedCount = Items.Where(e => e.IsChecked).Count();
        FilteredCheckedCount = ItemsView.OfType<CoMobile>().Where(e => e.IsChecked).Count();
    }

    public void CheckAll() => ItemsView.CheckAll<CoMobile>();
    public void UncheckAll() => ItemsView.UncheckAll<CoMobile>();

}
