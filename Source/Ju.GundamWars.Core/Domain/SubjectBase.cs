using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Domain.Tags;
using System.Collections.Specialized;
using System.Reactive.Linq;

namespace Ju.GundamWars.Domain;

public abstract partial class SubjectBase : GwObservableValidator, IIdentify, IKeyValues, ITaggable
{

    public SubjectBase()
    {
        IsIdle = false;

        Tags = [];

        Tags.CollectionChanged.Subscribe(WhenTagsChanged).AddTo(Disposables);
    }


    protected bool IsIdle { get; set; }

    public object[] KeyValues => new object[] { Id, };

    [ObservableProperty]
    private bool _IsChecked;

    #region Entity fields

    [ObservableProperty]
    private int _Id;

    #endregion

    #region Entity relationships

    public GwObservableCollection<TagSubject> Tags { get; }

    #endregion

    #region Extensions

    [ObservableProperty]
    private string _TagsText = "";

    #endregion

    public void ReAddTags(IList<TagSubject> tags)
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
