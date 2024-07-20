using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Factories;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Mobiles;

public partial class MobileEntryViewModel : EntryViewModelBase<MobileSubject, MobileEntryController, MobileSubjectFactory>
{

    public MobileEntryViewModel(
        MobileEntryController controller,
        MobileSubjectFactory factory,
        ISerialInventory serialInventory,
        IMobileKindInventory mobileKindInventory,
        IRoleInventory roleInventory,
        IPositionInventory positionInventory,
        IGradeInventory gradeInventory,
        ITerrainInventory terrainInventory,
        IHasAceInventory hasAceInventory,
        IMobileSSkillInventory mobileSSkillInventory,
        ITagInventory tagInventory)
        : base(controller, factory, tagInventory)
    {
        nCuspaSetters =
        [
            v => Entry.Cuspa1 = v,
            v => Entry.Cuspa2 = v,
            v => Entry.Cuspa3 = v,
            v => Entry.Cuspa4 = v,
            v => Entry.Cuspa5 = v,
            v => Entry.Cuspa6 = v,
        ];
        sCuspaSetters =
        [
            v => Entry.SCuspa1 = v,
            v => Entry.SCuspa2 = v,
            v => Entry.SCuspa3 = v,
            v => Entry.SCuspa4 = v,
        ];
        supportSetters =
        [
            v => Entry.Support1 = v,
            v => Entry.Support2 = v,
            v => Entry.Support3 = v,
            v => Entry.Support4 = v,
        ];
        CoMobileSetters =
        [
            v => Entry.CoMobile1 = v,
            v => Entry.CoMobile2 = v,
            v => Entry.CoMobile3 = v,
        ];
        PairSetter = v =>
        {
            Entry.PairId = v?.Id;
            Entry.Pair = v;
        };
        PilotSetter = v => Entry.Pilot = v;
        NCuspaSetter = null!;
        SCuspaSetter = null!;
        SupportSetter = null!;
        CoMobileSetter = null!;

        Serials = new(serialInventory);
        Kinds = new(mobileKindInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        Positions = new(positionInventory);
        InitialGrades = new(gradeInventory) { Filter = FilterInitialGrade, };
        Terrains = new(terrainInventory);
        Grades = new(gradeInventory) { Filter = FilterGrade, };
        HasAces = new(hasAceInventory);
        SSkills = new(mobileSSkillInventory);
        Tags = new(tagInventory) { Filter = FilterTag, };

        SSkills.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    }


    private readonly List<Action<CuspaSubject?>> nCuspaSetters;
    private readonly List<Action<CuspaSubject?>> sCuspaSetters;
    private readonly List<Action<SupportSubject?>> supportSetters;
    private readonly List<Action<CoMobileSubject?>> CoMobileSetters;

    private CategoryType CategoryType => Entry?.Category?.Type ?? CategoryType.Unknown;

    public Action<MobileSubject> PairSetter { get; private set; }
    public Action<PilotSubject> PilotSetter { get; private set; }
    public Action<CuspaSubject> NCuspaSetter { get; private set; }
    public Action<CuspaSubject> SCuspaSetter { get; private set; }
    public Action<SupportSubject> SupportSetter { get; private set; }
    public Action<CoMobileSubject> CoMobileSetter { get; private set; }

    public ListCollectionView Serials { get; }
    public ListCollectionView Kinds { get; }
    public ListCollectionView Roles { get; }
    public ListCollectionView Positions { get; }
    public ListCollectionView InitialGrades { get; }
    public ListCollectionView Terrains { get; }
    public ListCollectionView Grades { get; }
    public ListCollectionView HasAces { get; }
    public ListCollectionView SSkills { get; }
    public ListCollectionView Tags { get; }

    [ObservableProperty]
    private Serial? _Serial;


    private bool FilterRole(object obj)
    {
        if (obj is not Role item) return false;
        return (CategoryType == CategoryType.MobileSuit && item.Type.ForMobileSuit()) ||
            (CategoryType == CategoryType.MobileArmor && item.Type.ForMobileArmor());
    }

    private bool FilterInitialGrade(object obj)
    {
        if (obj is not Grade item) return false;
        return item.Type.ForMobileInitial();
    }

    private bool FilterGrade(object obj)
    {
        if (obj is not Grade item) return false;
        return item.Type.ForMobile();
    }

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForMobile();
    }

    public override void SetEntry(EntryMode mode, MobileSubject entry)
    {
        base.SetEntry(mode, entry);

        if (CategoryType == CategoryType.MobileSuit)
        {
            Icon = GwIcon.MobileSuit;
            Text = GwText.MobileSuit;
        }
        else if (CategoryType == CategoryType.MobileArmor)
        {
            Icon = GwIcon.MobileArmor;
            Text = GwText.MobileArmor;
        }

        Roles.Refresh();
    }

    [RelayCommand]
    private void AddSubSerial()
    {
        if (Serial != null && !Entry.SubSerials.Any(i => i.Id == Serial.Id))
        {
            Entry.SubSerials.Add(Serial);
        }
    }

    [RelayCommand]
    private void RemoveSubSerial(Serial? serial)
    {
        if (serial != null)
        {
            Entry.SubSerials.Remove(serial);
        }
    }

    [RelayCommand]
    private void ShowPairSelection(int _) => Controller.MoveToPairSelection();

    [RelayCommand]
    private void DetachPair(int _) => Entry.Pair = null;

    [RelayCommand]
    private void ShowPilotSelection(int _) => Controller.MoveToPilotSelection();

    [RelayCommand]
    private void DetachPilot(int _) => Entry.Pilot = null;

    [RelayCommand]
    private void ShowNCuspaSelection(int index)
    {
        NCuspaSetter = nCuspaSetters[index];
        Controller.MoveToNCuspaSelection();
    }

    [RelayCommand]
    private void DetachNCuspa(int index) => nCuspaSetters[index](null);

    [RelayCommand]
    private void ShowSCuspaSelection(int index)
    {
        SCuspaSetter = sCuspaSetters[index];
        Controller.MoveToSCuspaSelection();
    }

    [RelayCommand]
    private void DetachSCuspa(int index) => sCuspaSetters[index](null);

    [RelayCommand]
    private void ShowSupportSelection(int index)
    {
        SupportSetter = supportSetters[index];
        Controller.MoveToSupportSelection();
    }

    [RelayCommand]
    private void DetachSupport(int index) => supportSetters[index](null);

    [RelayCommand]
    private void ShowCoMobileSelection(int index)
    {
        CoMobileSetter = CoMobileSetters[index];
        Controller.MoveToCoMobileSelection();
    }

    [RelayCommand]
    private void DetachCoMobile(int index) => CoMobileSetters[index](null);

}
