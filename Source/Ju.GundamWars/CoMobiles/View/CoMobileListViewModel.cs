using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : ModelBase
{

    public CoMobileListViewModel(CoMobileInventory coMobiles)
    {
        ItemsView = new(coMobiles) { Filter = Filter, };
    }


    public ListCollectionView ItemsView { get; }


    protected bool Filter(object obj)
    {
        return true;
    }

}
