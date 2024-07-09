using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Factories;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.Collections.Generic;
using System.Windows.Data;

namespace Ju.GundamWars.Pilots;

public partial class PilotEntryViewModel : EntryViewModelBase<PilotSubject, PilotEntryController, PilotSubjectFactory>
{

    public PilotEntryViewModel(
        PilotEntryController controller,
        PilotSubjectFactory factory,
        ISerialInventory serialInventory,
        IGradeInventory gradeInventory,
        ITagInventory tagInventory,
        IPilotAbilityInventory pilotAbilityInventory,
        IPilotSkillInventory pilotSkillInventory)
        : base(controller, factory, tagInventory)
    {
        Icon = GwIcon.Pilot;
        Text = GwText.Pilot;

        Serials = new(serialInventory);
        Grades = new(gradeInventory) { Filter = FilterGrade, };
        Tags = new(tagInventory) { Filter = FilterTag, };
        SlotRanks = [1, 2, 3, 4, 5,];
        Abilities = new(pilotAbilityInventory);
        Skills = new(pilotSkillInventory);

        Abilities.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        Skills.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    }


    public ListCollectionView Serials { get; }
    public ListCollectionView Grades { get; }
    public ListCollectionView Tags { get; }
    public List<int> SlotRanks { get; }
    public ListCollectionView Abilities { get; }
    public ListCollectionView Skills { get; }


    private bool FilterGrade(object obj)
    {
        if (obj is not Grade item) return false;
        return item.Type.ForPilot();
    }

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForPilot();
    }

    [RelayCommand]
    private void ResetPracticed() => Entry.ResetPracticed();

}
