using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizListViewModelBase2<TBiz, TViewState> : ModelBase
    where TBiz : BizBase, new()
    where TViewState : BizViewStateBase
{

    public BizListViewModelBase2(TViewState viewState, ObservableItemPropertyChangedCollection<TBiz> items, TagInventory tagInventory)
    {
        IsIdle = false;
        ViewState = viewState;
        Items = items;
        ItemsView = new(items) { Filter = FilterItem, };
        Tags = new(tagInventory) { Filter = FilterTag, };

        Items.ItemPropertyChanged.Where(e => e.PropertyName == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
    }


    protected bool IsIdle { get; set; }
    protected TViewState ViewState { get; }

    protected Func<IDisposable>? CreateEntryViewModelAsNew { get; set; } = null;
    protected Func<TBiz, IDisposable>? CreateEntryViewModelAsEdit { get; set; } = null;
    protected Func<TBiz, IDisposable>? CreateEntryViewModelAsCopy { get; set; } = null;

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

    private void WhenIsCheckedChanged(PropertyChangedEventArgs _) => SetCount();

    protected abstract bool FilterItem(object obj);
    protected abstract bool FilterTag(object obj);
    protected abstract void ClearFilterCore();

    protected void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
        SetCount();
    }

    public void SetCount()
    {
        if (!IsCountableChecked) return;
        CheckedCount = Items.Where(e => e.IsChecked).Count();
        FilteredCheckedCount = ItemsView.OfType<TBiz>().Where(e => e.IsChecked).Count();
    }

    [RelayCommand]
    private void ClearFilter() => ClearFilterCore();
    [RelayCommand]
    private void CheckAll() => ItemsView.OfType<TBiz>().ToList().ForEach(i => i.IsChecked = true);
    [RelayCommand]
    private void UncheckAll() => ItemsView.OfType<TBiz>().ToList().ForEach(i => i.IsChecked = false);

    [RelayCommand]
    private Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            ViewState.EntryContent = CreateEntryViewModelAsNew?.Invoke();
            ViewState.PageIndexType = PageIndexType.Entry;
        });

    [RelayCommand]
    private Task OpenEntryAsEditAsync(TBiz model) =>
        Task.Run(() =>
        {
            ViewState.EntryContent = CreateEntryViewModelAsEdit?.Invoke(model);
            ViewState.PageIndexType = PageIndexType.Entry;
        });

    [RelayCommand]
    private Task OpenEntryAsCopyAsync(TBiz model) =>
        Task.Run(() =>
        {
            ViewState.EntryContent = CreateEntryViewModelAsCopy?.Invoke(model);
            ViewState.PageIndexType = PageIndexType.Entry;
        });

}
