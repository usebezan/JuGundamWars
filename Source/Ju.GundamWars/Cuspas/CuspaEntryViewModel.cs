using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Cuspas.Domain.Factories;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.Windows.Data;

namespace Ju.GundamWars.Cuspas;

public partial class CuspaEntryViewModel : EntryViewModelBase<CuspaSubject, CuspaEntryController, CuspaSubjectFactory>
{

    public CuspaEntryViewModel(
        CuspaEntryController controller,
        CuspaSubjectFactory factory,
        ICuspaKindInventory cuspaKindInventory,
        ITagInventory tagInventory)
        : base(controller, factory, tagInventory)
    {
        Icon = GwIcon.Cuspa;
        Text = GwText.Cuspa;

        Kinds = new(cuspaKindInventory);
        Tags = new(tagInventory) { Filter = FilterTag, };

        Kinds.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    }


    public override int TabIndex => Mode == EntryMode.New ? 0 : (Mode == EntryMode.Copy ? 1 : 2);

    public ListCollectionView Kinds { get; }
    public ListCollectionView Tags { get; }


    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForCuspa();
    }

}
