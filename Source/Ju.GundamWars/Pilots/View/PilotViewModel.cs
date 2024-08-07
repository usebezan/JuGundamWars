using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotViewModel(PilotListViewModel listViewModel)
    : PageControllerViewModelBase<Pilot, PilotListViewModel>(listViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForMaAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
