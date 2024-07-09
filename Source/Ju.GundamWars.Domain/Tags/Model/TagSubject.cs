using CommunityToolkit.Mvvm.ComponentModel;

namespace Ju.GundamWars.Domain.Tags.Model;

public partial class TagSubject : GwObservableObject, ITag
{

    [ObservableProperty]
    private bool _IsChecked;

    #region Primitives

    [ObservableProperty]
    private int _Id;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(GroupText))]
    private TagGroupType _Group;
    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty]
    private int _Order;

    #endregion

    #region Extensions

    public string GroupText => Group.ToText();

    #endregion

}
