using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaViewModel(CuspaListViewModel listViewModel)
    : PageControllerViewModelBase<Cuspa, CuspaListViewModel>(listViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForBsAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
