using Ju.GundamWars.CoMobiles.Domain;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : ListViewModelBase<CoMobileList, CoMobileViewState>
{
    public CoMobileListViewModel(CoMobileList list, CoMobileViewState viewState)
        : base(list, viewState)
    {
        list.IsCountable = true;
    }
}
