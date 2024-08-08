using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizEntryViewModelBase2<TBiz> : ModelBase
    where TBiz : BizBase, new()
{

    public BizEntryViewModelBase2(
        IUseCase<TBiz, TBiz> insertCoMobileClientUseCase,
        IUseCase<TBiz, TBiz> updateCoMobileClientUseCase,
        IUseCase<TBiz, TBiz> deleteCoMobileClientUseCase,
        IMapper<TBiz, TBiz> mapper,
        TagInventory tagInventory)
    {
        InsertCoMobileClientUseCase = insertCoMobileClientUseCase;
        UpdateCoMobileClientUseCase = updateCoMobileClientUseCase;
        DeleteCoMobileClientUseCase = deleteCoMobileClientUseCase;
        Mapper = mapper;
        TagInventory = tagInventory;
        Origin = null;
        Tags = new(tagInventory) { Filter = FilterTag, };
    }


    protected IUseCase<TBiz, TBiz> InsertCoMobileClientUseCase { get; }
    protected IUseCase<TBiz, TBiz> UpdateCoMobileClientUseCase { get; }
    protected IUseCase<TBiz, TBiz> DeleteCoMobileClientUseCase { get; }
    protected IMapper<TBiz, TBiz> Mapper { get; }
    protected TagInventory TagInventory { get; }
    protected TBiz? Origin { get; set; }

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

    public abstract Task CancelAsyncCore();

    public Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            Mode = EntryMode.New;
            Model = new();
            Origin = null;
            ResetTags(Model);
        });

    public Task OpenEntryAsEditAsync(TBiz model) =>
        Task.Run(() =>
        {
            Mode = EntryMode.Edit;
            Model = model;
            Origin = Mapper.Map(model, new());
            ResetTags(Model);
        });

    public Task OpenEntryAsCopyAsync(TBiz model) =>
        Task.Run(() =>
        {
            Mode = EntryMode.Copy;
            Model = Mapper.Map(model, new());
            Origin = null;
            ResetTags(Model);
        });

    [RelayCommand]
    private Task CancelAsync() => CancelAsyncCore();

    [RelayCommand]
    private Task EnterAsync()
    {
        if (IsAdd)
        {
            Model.ReAddTags(TagInventory.Where(i => i.IsChecked).ToList());
            return InsertCoMobileClientUseCase.HandleAsync(Model);
        }
        else if (IsEdit)
        {
            Model.ReAddTags(TagInventory.Where(i => i.IsChecked).ToList());
            return UpdateCoMobileClientUseCase.HandleAsync(Model);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [RelayCommand]
    private Task DeleteAsync() => DeleteCoMobileClientUseCase.HandleAsync(Model);

}
