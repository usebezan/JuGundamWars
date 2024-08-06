using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Supports.Domain;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportListViewModel : ListViewModelBase<Support, SupportList, SupportViewState>
{
    public SupportListViewModel(SupportList list, SupportViewState viewState)
        : base(list, viewState)
    {
        list.IsCountable = true;
    }
}
