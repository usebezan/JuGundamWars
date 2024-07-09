using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Pilots;

public abstract partial class PilotListViewModelBase : GwObservableObject
{

    public PilotListViewModelBase(
        IPilotInventory pilotInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        IPilotAbilityInventory pilotAbilityInventory,
        IPilotSkillInventory pilotSkillInventory)
    {
        ItemsView = new(pilotInventory) { Filter = Filter, };
        Serials = new(serialInventory);
        Tags = new(tagInventory) { Filter = FilterTag, };
        Abilities = new(pilotAbilityInventory);
        Skills = new(pilotSkillInventory);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
        Abilities.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        Skills.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    }


    protected bool IsIdle { get; set; }

    public ListCollectionView ItemsView { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView Tags { get; }
    public ListCollectionView Abilities { get; }
    public ListCollectionView Skills { get; }

    [ObservableProperty]
    private Category? _Category;
    [ObservableProperty]
    private string _Word = string.Empty;
    [ObservableProperty]
    private bool _HasMemo = false;
    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty]
    private TagSubject? _Tag;
    [ObservableProperty]
    private PilotAbility? _Ability;
    [ObservableProperty]
    private PilotSkill? _Skill;


    partial void OnCategoryChanged(Category? value) => Refresh();
    partial void OnWordChanged(string value) => Refresh();
    partial void OnHasMemoChanged(bool value) => Refresh();
    partial void OnSerialChanged(Serial? value) => Refresh();
    partial void OnTagChanged(TagSubject? value) => Refresh();
    partial void OnAbilityChanged(PilotAbility? value) => Refresh();
    partial void OnSkillChanged(PilotSkill? value) => Refresh();

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.KindType.ForPilot();
    }

    protected abstract bool Filter(object obj);

    protected bool FilterCore(PilotSubject item)
    {
        if (Category != null && item.Category?.Type != Category.Type) return false;
        if (!string.IsNullOrEmpty(Word) &&
            !item.Name.Contains(Word) &&
            !(item.Skill?.Name ?? string.Empty).Contains(Word) &&
            !(item.SkillText1 ?? string.Empty).Contains(Word) &&
            !(item.SkillText2 ?? string.Empty).Contains(Word) &&
            !(item.Memo ?? string.Empty).Contains(Word)) return false;
        if (HasMemo && !item.HasMemo) return false;
        if (Serial != null && item.Serial?.Id != Serial.Id) return false;
        if (Tag != null && !item.Tags.Any(s => s.Id == Tag.Id)) return false;
        if (Ability != null &&
            item.Ability1?.Id != Ability.Id &&
            item.Ability2?.Id != Ability.Id &&
            item.Ability3?.Id != Ability.Id) return false;
        if (Skill != null && item.Skill?.Id != Skill.Id) return false;
        return true;
    }

    // Category はここではクリアしない
    protected void ClearCore()
    {
        Word = string.Empty;
        HasMemo = false;
        Serial = null;
        Tag = null;
        Ability = null;
        Skill = null;
    }

    protected virtual void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
    }

}
