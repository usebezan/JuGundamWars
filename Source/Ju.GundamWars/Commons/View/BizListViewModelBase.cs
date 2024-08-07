using CommunityToolkit.Mvvm.ComponentModel;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizListViewModelBase<TBiz> : ModelBase
    where TBiz : BizBase
{

    public BizListViewModelBase(ObservableItemPropertyChangedCollection<TBiz> items, TagInventory tags)
    {
        Items = items;
        ItemsView = new(items) { Filter = FilterItem, };
        Tags = new(tags) { Filter = FilterTag, };

        Items.ItemPropertyChanged.Where(e => e.PropertyName == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
    }


    protected bool IsIdle { get; set; } = false;

    public ObservableItemPropertyChangedCollection<TBiz> Items { get; }
    public ListCollectionView ItemsView { get; }
    public ListCollectionView Tags { get; }

    [ObservableProperty]
    private Tag? _TagFilter = null;

    [ObservableProperty]
    private bool _IsCountableChecked = false;
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

    public abstract void ClearFilter();

    public void SetCount()
    {
        if (!IsCountableChecked) return;
        CheckedCount = Items.Where(e => e.IsChecked).Count();
        FilteredCheckedCount = ItemsView.OfType<TBiz>().Where(e => e.IsChecked).Count();
    }

    public void CheckAll()
    {
        foreach (var item in ItemsView.OfType<TBiz>().ToList())
        {
            item.IsChecked = true;
        }
    }

    public void UncheckAll()
    {
        foreach (var item in ItemsView.OfType<TBiz>().ToList())
        {
            item.IsChecked = false;
        }
    }

}
