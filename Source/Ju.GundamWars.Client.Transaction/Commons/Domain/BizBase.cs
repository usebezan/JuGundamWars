using CommunityToolkit.Mvvm.ComponentModel;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.Collections.Specialized;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.Commons.Domain;

public partial class BizBase : ModelBase, IIdentifiable
{

    public BizBase()
    {
        Tags = [];

        Tags.CollectionChanged.Subscribe(WhenTagsChanged).AddTo(Disposables);
    }


    protected bool IsIdle { get; set; }

    [ObservableProperty]
    private bool _IsChecked;

    #region Primitives

    [ObservableProperty]
    private int _Id;

    #endregion

    #region Navigations

    public ObservableItemPropertyChangedCollection<Tag> Tags { get; }

    #endregion

    #region Extensions

    [ObservableProperty]
    private string _TagsText = "";

    #endregion


    public void ReAddTags(IList<Tag> tags)
    {
        Suspend(() => Tags.ReAddRange(tags));
        SetJoinedTags();
    }

    protected void Suspend(Action invoker)
    {
        IsIdle = false;
        invoker();
        IsIdle = true;
    }

    protected void RaiseMobileBoostChanged() =>
        OnPropertyChanged("MobileBoost");

    protected void SetJoinedTags() =>
        TagsText = string.Join(", ", Tags.OrderBy(i => i.Order).Select(i => i.Name));

    private void WhenTagsChanged(NotifyCollectionChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetJoinedTags();
    }

}
