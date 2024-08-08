using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class PageControllerViewModelBase<TBiz, TBizListViewModel, TBizEntryViewModel>(
    TBizListViewModel listViewModel,
    TBizEntryViewModel entryViewModel) : ModelBase
    where TBiz : BizBase
    where TBizListViewModel : BizListViewModelBase<TBiz>
    where TBizEntryViewModel : BizEntryViewModelBase<TBiz>
{

    public TBizListViewModel List { get; } = listViewModel;
    public TBizEntryViewModel Entry { get; } = entryViewModel;

    [ObservableProperty]
    private int _PageIndex = 0;


    [RelayCommand]
    private async Task OpenEntryAsNewAsync()
    {
        await Entry.OpenEntryAsNewAsync();
        PageIndex = 1;
    }

    [RelayCommand]
    private async Task OpenEntryAsEditAsync(TBiz model)
    {
        await Entry.OpenEntryAsEditAsync(model);
        PageIndex = 1;
    }

    [RelayCommand]
    private async Task OpenEntryAsCopyAsync(TBiz model)
    {
        await Entry.OpenEntryAsCopyAsync(model);
        PageIndex = 1;
    }

    [RelayCommand]
    private async Task CancelAsync()
    {
        await Entry.CancelAsync();
        PageIndex = 0;
    }

    [RelayCommand]
    private async Task EnterAsync()
    {
        await Entry.EnterAsync();
        PageIndex = 0;
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await Entry.DeleteAsync();
        PageIndex = 0;
    }

    [RelayCommand]
    private void ClearFilter() => List.ClearFilter();
    [RelayCommand]
    private void CheckAll() => List.CheckAll();
    [RelayCommand]
    private void UncheckAll() => List.UncheckAll();

}
