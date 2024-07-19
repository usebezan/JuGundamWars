using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Tags.Domain;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Model;

public partial class Tag : ModelBase, ITag
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
