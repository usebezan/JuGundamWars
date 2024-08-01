using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Cuspas.Domain;

namespace Ju.GundamWars.Cuspas.View;

internal class CuspaEntryViewModel : EntryViewModelBase<CuspaViewState>
{

    public CuspaEntryViewModel(
        CuspaViewState viewState,
        TagInventory tags)
        : base(viewState)
    {
    }

}
