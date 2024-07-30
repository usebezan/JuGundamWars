using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal abstract partial class CoMobileListViewModelBase : ModelBase
{

    public CoMobileListViewModelBase(
        CoMobileInventory coMobiles,
        SerialInventory serials,
        TagInventory tags)
    {
        ItemsView = new(coMobiles) { Filter = Filter, };
        Serials = new(serials);
        Tags = new(tags) { Filter = FilterTag, };
    }


    public ListCollectionView ItemsView { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView Tags { get; }


    private bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCoMobile();
    }

    protected abstract bool Filter(object obj);

}
