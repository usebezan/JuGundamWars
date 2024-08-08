using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizEntryViewModelBase<TBiz> : ModelBase
    where TBiz : BizBase
{

    public BizEntryViewModelBase(TagInventory tagInventory)
    {
        TagInventory = tagInventory;
        Tags = new(tagInventory) { Filter = FilterTag, };
    }


    protected TBiz? Origin { get; set; } = null;
    protected TagInventory TagInventory { get; }

    public ListCollectionView Tags { get; }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(IsAdd)), NotifyPropertyChangedFor(nameof(IsEdit)), NotifyPropertyChangedFor(nameof(TabIndex))]
    private EntryMode _Mode = EntryMode.New;
    [ObservableProperty]
    private TBiz _Model = null!;
    //[ObservableProperty]
    //private string _Icon;
    //[ObservableProperty]
    //private string _Text;

    public bool IsAdd => Mode == EntryMode.New || Mode == EntryMode.Copy;
    public bool IsEdit => Mode == EntryMode.Edit;
    public virtual int TabIndex => Mode == EntryMode.New ? 0 : 2;


    protected abstract bool FilterTag(object obj);

    protected void ResetTags(TBiz model)
    {
        foreach (var tag in TagInventory)
        {
            tag.IsChecked = model.Tags.Contains(tag);
        }
    }

    public abstract Task OpenEntryAsNewAsync();
    public abstract Task OpenEntryAsEditAsync(TBiz model);
    public abstract Task OpenEntryAsCopyAsync(TBiz model);
    public abstract Task CancelAsync();
    public abstract Task EnterAsync();
    public abstract Task DeleteAsync();

}
