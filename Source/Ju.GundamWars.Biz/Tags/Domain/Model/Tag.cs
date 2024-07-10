using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizMaster.TagGroups.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Model;

public partial class Tag : ModelBase, ITag
{

    [ObservableProperty]
    private bool _IsChecked;

    #region Primitives

    [ObservableProperty]
    private int _Id;
    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(GroupText))]
    private TagGroupType _Group;
    [ObservableProperty]
    private int _Order;

    #endregion

    #region Extensions

    public string GroupText => Group.ToText();

    #endregion

}
