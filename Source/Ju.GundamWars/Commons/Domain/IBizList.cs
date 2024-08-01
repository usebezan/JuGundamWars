using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.Domain;

internal interface IBizList<TBiz>
    where TBiz : BizBase
{
    ObservableItemPropertyChangedCollection<TBiz> Items { get; }
    ListCollectionView ItemsView { get; }
    int CheckedCount { get; }
    int FilteredCheckedCount { get; }
    void FilterClear();
    void CheckAll();
    void UncheckAll();
}
