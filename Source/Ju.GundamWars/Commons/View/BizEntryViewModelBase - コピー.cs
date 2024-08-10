using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using System.Windows.Data;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizEntryViewModelBase2<TBiz> : ModelBase
    where TBiz : BizBase, new()
{

    public BizEntryViewModelBase2(
        EntryMode mode,
        TBiz model,
        IUseCase<TBiz, TBiz> insertClientUseCase,
        IUseCase<TBiz, TBiz> updateClientUseCase,
        IUseCase<TBiz, TBiz> deleteClientUseCase,
        ICancelEntryUseCase<TBiz> cancelClientUseCase,
        IMapper<TBiz, TBiz> mapper,
        TagInventory tagInventory)
    {
        InsertClientUseCase = insertClientUseCase;
        UpdateClientUseCase = updateClientUseCase;
        DeleteClientUseCase = deleteClientUseCase;
        CancelClientUseCase = cancelClientUseCase;
        Mapper = mapper;
        TagInventory = tagInventory;
        Tags = new(tagInventory) { Filter = FilterTag, };

        Mode = mode;
        IsAdd = Mode == EntryMode.New || Mode == EntryMode.Copy;
        IsEdit = Mode == EntryMode.Edit;
        TabIndex = Mode == EntryMode.New ? 0 : 2;
        if (Mode == EntryMode.New)
        {
            Model = model;
            Origin = null;
        }
        else if (Mode == EntryMode.Edit)
        {
            Model = model;
            Origin = Mapper.Map(model, new());
        }
        else if (Mode == EntryMode.Copy)
        {
            Model = Mapper.Map(model, new());
            Origin = null;
        }
        else
        {
            throw new InvalidOperationException();
        }
        ResetTags(Model);
    }


    protected TBiz? Origin { get; set; }
    protected IUseCase<TBiz, TBiz> InsertClientUseCase { get; }
    protected IUseCase<TBiz, TBiz> UpdateClientUseCase { get; }
    protected IUseCase<TBiz, TBiz> DeleteClientUseCase { get; }
    protected ICancelEntryUseCase<TBiz> CancelClientUseCase { get; }
    protected IMapper<TBiz, TBiz> Mapper { get; }
    protected TagInventory TagInventory { get; }

    public EntryMode Mode { get; }
    public bool IsAdd { get; }
    public bool IsEdit { get; }
    public int TabIndex { get; set; }
    public TBiz Model { get; }
    public ListCollectionView Tags { get; }


    protected abstract bool FilterTag(object obj);

    protected void ResetTags(TBiz model)
    {
        foreach (var tag in TagInventory)
        {
            tag.IsChecked = model.Tags.Contains(tag);
        }
    }

    [RelayCommand]
    private void UncheckAllTags() => TagInventory.UncheckAll();

    [RelayCommand]
    private Task EnterAsync()
    {
        if (IsAdd)
        {
            Model.ReAddTags(TagInventory.Where(i => i.IsChecked).ToList());
            return InsertClientUseCase.HandleAsync(Model);
        }
        else if (IsEdit)
        {
            Model.ReAddTags(TagInventory.Where(i => i.IsChecked).ToList());
            return UpdateClientUseCase.HandleAsync(Model);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [RelayCommand]
    private Task DeleteAsync() => DeleteClientUseCase.HandleAsync(Model);
    [RelayCommand]
    private Task CancelAsync() => CancelClientUseCase.HandleAsync((Mode, Model, Origin));

}
