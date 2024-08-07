using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal interface IBizListViewModel<TBiz>
    where TBiz : BizBase
{
    ObservableItemPropertyChangedCollection<TBiz> Items { get; }
    ListCollectionView ItemsView { get; }
    int CheckedCount { get; }
    int FilteredCheckedCount { get; }
    void ClearFilter();
    void CheckAll();
    void UncheckAll();
}
