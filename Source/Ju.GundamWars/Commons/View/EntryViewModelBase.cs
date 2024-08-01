using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class EntryViewModelBase<TViewState>(TViewState viewState) : ModelBase
    where TViewState : IPageController
{

    protected TViewState ViewState { get; set; } = viewState;


    [RelayCommand]
    private Task CancelAsync()
    {
        return Task.Run(() =>
        {
            ViewState.PageIndex = 0;
        });
    }

}
