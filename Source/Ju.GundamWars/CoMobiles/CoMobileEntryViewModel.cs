using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Factories;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.Collections.Generic;
using System.Windows.Data;

namespace Ju.GundamWars.CoUnits;

public partial class CoUnitEntryViewModel : EntryViewModelBase<CoUnitSubject, CoUnitEntryController, CoUnitSubjectFactory>
{

    public CoUnitEntryViewModel(
        CoUnitEntryController controller,
        CoUnitSubjectFactory subjectFactory,
        ISerialInventory serialInventory,
        IRoleInventory roleInventory,
        ITagInventory tagInventory)
        : base(controller, subjectFactory, tagInventory)
    {
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        Tags = new(tagInventory) { Filter = FilterTag, };
        UpgradedCounts = [0, 1, 2, 3, 4, 5,];
    }


    private CategoryType CategoryType => Entry?.Category?.Type ?? CategoryType.Unknown;

    public ListCollectionView Serials { get; }
    public ListCollectionView Roles { get; }
    public ListCollectionView Tags { get; }
    public List<int> UpgradedCounts { get; }


    private bool FilterRole(object obj)
    {
        if (obj is not Role item) return false;
        return (CategoryType == CategoryType.MobileSuit && item.Type.ForMobileSuit()) ||
            (CategoryType == CategoryType.MobileArmor && item.Type.ForMobileArmor());
    }

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForCoUnit();
    }

    public override void SetEntry(EntryMode mode, CoUnitSubject entry)
    {
        base.SetEntry(mode, entry);

        if (CategoryType == CategoryType.MobileSuit)
        {
            Icon = GwIcon.CoUnitSuit;
            Text = GwText.CoUnitSuit;
        }
        else if (CategoryType == CategoryType.MobileArmor)
        {
            Icon = GwIcon.CoUnitArmor;
            Text = GwText.CoUnitArmor;
        }

        Roles.Refresh();
    }

    [RelayCommand]
    private void ResetUpgraded() => Entry.ResetUpgraded();

}
