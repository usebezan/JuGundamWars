using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Tags;

public partial class TagSubject : GwObservableObject, IIdentify
{

    [ObservableProperty]
    private bool _IsChecked;

    #region Entity fields

    [ObservableProperty]
    private int _Id;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Group))]
    private TagKindType _KindType;
    [ObservableProperty]
    private string _Name = null!;
    [ObservableProperty]
    private int _Order;

    #endregion

    #region Extensions

    public string Group => KindType.ToText();

    #endregion

}
