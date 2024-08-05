using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Pilots.Domain;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotListViewModel : ListViewModelBase<Pilot, PilotList, PilotViewState>
{
    public PilotListViewModel(PilotList list, PilotViewState viewState)
        : base(list, viewState)
    {
        list.IsCountable = true;
    }
}
