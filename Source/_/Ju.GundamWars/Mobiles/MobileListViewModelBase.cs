using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Mobiles;

public abstract partial class MobileListViewModelBase : GwObservableObject
{

    public MobileListViewModelBase(IMobileInventory mobileInventory, ISerialInventory serialInventory, ITagInventory tagInventory)
    {
        ItemsView = new(mobileInventory) { Filter = Filter, };
        Serials = new(serialInventory);
        Tags = new(tagInventory) { Filter = FilterTag, };

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
    }


    protected bool IsIdle { get; set; } = false;

    public ListCollectionView ItemsView { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView Tags { get; }

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


    partial void OnCategoryChanged(Category? value) => Refresh();
    partial void OnWordChanged(string value) => Refresh();
    partial void OnHasMemoChanged(bool value) => Refresh();
    partial void OnSerialChanged(Serial? value) => Refresh();
    partial void OnTagChanged(TagSubject? value) => Refresh();

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.KindType.ForMobile();
    }

    protected abstract bool Filter(object obj);

    protected bool FilterCore(MobileSubject item)
    {
        if (Category != null && item.Category?.Type != Category.Type) return false;
        if (!string.IsNullOrEmpty(Word) &&
            !item.Name.Contains(Word) &&
            !(item.Memo ?? string.Empty).Contains(Word)) return false;
        if (HasMemo && !item.HasMemo) return false;
        if (Serial != null && item.Serial?.Id != Serial.Id) return false;
        if (Tag != null && !item.Tags.Any(i => i.Id == Tag.Id)) return false;
        return true;
    }

    // Category はここではクリアしない
    protected void ClearCore()
    {
        Word = string.Empty;
        HasMemo = false;
        Serial = null;
        Tag = null;
    }

    protected virtual void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
    }

}
