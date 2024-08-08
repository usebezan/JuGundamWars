using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizListViewModelBase2<TBiz, TPageControllerViewModel, TEntryViewModel> : ModelBase
    where TBiz : BizBase, new()
    where TPageControllerViewModel : PageControllerViewModelBase2
    where TEntryViewModel : BizEntryViewModelBase2<TBiz>
{

    public BizListViewModelBase2(TPageControllerViewModel pageControllerViewModel, TEntryViewModel entryViewModel, ObservableItemPropertyChangedCollection<TBiz> items, TagInventory tagInventory)
    {
        PageControllerViewModel = pageControllerViewModel;
        EntryViewModel = entryViewModel;
        Items = items;
        ItemsView = new(items) { Filter = FilterItem, };
        Tags = new(tagInventory) { Filter = FilterTag, };

        Items.ItemPropertyChanged.Where(e => e.PropertyName == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
    }


    protected bool IsIdle { get; set; } = false;
    protected TPageControllerViewModel PageControllerViewModel { get; }
    protected TEntryViewModel EntryViewModel { get; }

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
    private void CheckAll()
    {
        foreach (var item in ItemsView.OfType<TBiz>().ToList())
        {
            item.IsChecked = true;
        }
    }

    [RelayCommand]
    private void UncheckAll()
    {
        foreach (var item in ItemsView.OfType<TBiz>().ToList())
        {
            item.IsChecked = false;
        }
    }

    [RelayCommand]
    private async Task OpenEntryAsNewAsync()
    {
        await EntryViewModel.OpenEntryAsNewAsync();
        PageControllerViewModel.PageIndex = 1;
    }

    [RelayCommand]
    private async Task OpenEntryAsEditAsync(TBiz model)
    {
        await EntryViewModel.OpenEntryAsEditAsync(model);
        PageControllerViewModel.PageIndex = 1;
    }

    [RelayCommand]
    private async Task OpenEntryAsCopyAsync(TBiz model)
    {
        await EntryViewModel.OpenEntryAsCopyAsync(model);
        PageControllerViewModel.PageIndex = 1;
    }

}
