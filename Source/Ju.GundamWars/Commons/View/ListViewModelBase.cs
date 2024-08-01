using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class ListViewModelBase<TBiz, TBizList, TViewState>(TBizList list, TViewState viewState) : ModelBase
    where TBiz : BizBase
    where TBizList : IBizList<TBiz>
    where TViewState : IPageController
{

    protected TViewState ViewState { get; } = viewState;

    public TBizList List { get; } = list;


    [RelayCommand]
    private Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            ViewState.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsEditAsync(TBiz model) =>
        Task.Run(() =>
        {
            ViewState.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsCopyAsync(TBiz model) =>
        Task.Run(() =>
        {
            ViewState.PageIndex = 1;
        });

    [RelayCommand]
    private void FilterClear() => List.FilterClear();
    [RelayCommand]
    private void CheckAll() => List.CheckAll();
    [RelayCommand]
    private void UncheckAll() => List.UncheckAll();

}
