using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class PageControllerViewModelBase<TBiz, TBizListViewModel>(TBizListViewModel listViewModel) : ModelBase
    where TBiz : BizBase
    where TBizListViewModel : IBizListViewModel<TBiz>
{

    public TBizListViewModel List { get; } = listViewModel;

    [ObservableProperty]
    private int _PageIndex = 0;


    [RelayCommand]
    private Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsEditAsync(TBiz model) =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsCopyAsync(TBiz model) =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });

    [RelayCommand]
    private Task CancelAsync() =>
        Task.Run(() =>
        {
            PageIndex = 0;
        });

    [RelayCommand]
    private void ClearFilter() => List.ClearFilter();
    [RelayCommand]
    private void CheckAll() => List.CheckAll();
    [RelayCommand]
    private void UncheckAll() => List.UncheckAll();

}
