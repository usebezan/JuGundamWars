using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Cuspas;

public abstract partial class CuspaListViewModelBase : GwObservableObject
{

    public CuspaListViewModelBase(ICuspaInventory cuspaInventory, ITagInventory tagInventory, ICuspaKindInventory cuspaKindInventory)
    {
        ItemsView = new(cuspaInventory) { Filter = Filter, };
        Tags = new(tagInventory) { Filter = FilterTag, };
        Kinds = new(cuspaKindInventory);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
        Kinds.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    }


    protected bool IsIdle { get; set; } = false;

    public ListCollectionView ItemsView { get; }
    public ListCollectionView Tags { get; }
    public ListCollectionView Kinds { get; }

    [ObservableProperty]
    private Category? _Category;
    [ObservableProperty]
    private int? _GroupKind;
    [ObservableProperty]
    private string _Word = string.Empty;
    [ObservableProperty]
    private bool _HasMemo = false;
    [ObservableProperty]
    private TagSubject? _Tag;
    [ObservableProperty]
    private CuspaKind? _Kind;


    partial void OnCategoryChanged(Category? value) => Refresh();
    partial void OnGroupKindChanged(int? value) => Refresh();
    partial void OnWordChanged(string value) => Refresh();
    partial void OnHasMemoChanged(bool value) => Refresh();
    partial void OnTagChanged(TagSubject? value) => Refresh();
    partial void OnKindChanged(CuspaKind? value) => Refresh();

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.KindType.ForCuspa();
    }

    private bool Filter(object obj)
    {
        if (obj is not CuspaSubject item) return false;
        if (Category != null && item.Category?.Type != Category.Type) return false;
        // FIXME: magic number
        if (GroupKind != null &&
            (GroupKind == 1 && item.Kind != null && !item.Kind.Type.ForNormal() ||
            GroupKind == 2 && item.Kind != null && !item.Kind.Type.ForSuper())) return false;
        if (!string.IsNullOrEmpty(Word) &&
            !item.Name.Contains(Word) &&
            !(item.Memo ?? string.Empty).Contains(Word)) return false;
        if (HasMemo && !item.HasMemo) return false;
        if (Tag != null && !item.Tags.Any(i => i.Id == Tag.Id)) return false;
        if (Kind != null && item.Kind?.Type != Kind.Type) return false;
        return true;
    }

    // Category, GroupKind はここではクリアしない
    protected void ClearCore()
    {
        Word = string.Empty;
        HasMemo = false;
        Tag = null;
        Kind = null;
    }

    protected virtual void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
    }

}
