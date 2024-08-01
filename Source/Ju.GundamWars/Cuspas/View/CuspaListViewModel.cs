using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Cuspas.Domain;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaListViewModel : ListViewModelBase<Cuspa, CuspaList, CuspaViewState>
{
    public CuspaListViewModel(CuspaList list, CuspaViewState viewState)
        : base(list, viewState)
    {
        list.IsCountable = true;
    }
}
