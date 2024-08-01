using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.CoMobiles.View;

internal abstract partial class ListViewModelBase<TBizList, TViewState>(TBizList list, TViewState viewState) : ModelBase
    where TBizList : IBizList
    where TViewState : IPageController
{

    protected TViewState ViewState { get; set; } = viewState;

    public TBizList List { get; set; } = list;


    [RelayCommand]
    private Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            ViewState.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsEditAsync(CoMobile model) =>
        Task.Run(() =>
        {
            ViewState.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsCopyAsync(CoMobile model) =>
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
