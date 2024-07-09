using CommunityToolkit.Mvvm.ComponentModel;

namespace Ju.GundamWars.Domain.Skills.Model;

public partial class SkillSubject : GwObservableObject, ISkill
{

    [ObservableProperty]
    private bool _IsChecked;

    #region Primitives

    [ObservableProperty]
    private int _Id;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(GroupText))]
    private SkillGroupType _Group;
    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty]
    private int _Order;

    #endregion

    #region Extensions

    public string GroupText => Group.ToText();

    #endregion

}
