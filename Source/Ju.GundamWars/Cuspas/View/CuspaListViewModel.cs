using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Cuspas.Infrastructure.WebClient;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaListViewModel : CuspaListViewModelBase
{

    public CuspaListViewModel(
        CuspaInventory itemInventory,
        UnitInventory unitInventory,
        CuspaKindInventory cuspaKindInventory,
        BoostStatusInventory boostStatusInventory,
        TagInventory tagInventory,
        ViewState viewState)
        : base(itemInventory, unitInventory, cuspaKindInventory, boostStatusInventory, tagInventory, viewState)
    {
        IsCountableChecked = false;
        IsFixedForUnitFilter = false;
        IsIdle = true;
    }


    protected override IDisposable CreateEntryViewModelAsNew() =>
        CreateEntryViewModel(EntryMode.New, new() { ForUnitType = UnitType.Mobile, });

    protected override IDisposable CreateEntryViewModelAsEdit(Cuspa model) =>
        CreateEntryViewModel(EntryMode.Edit, model);

    protected override IDisposable CreateEntryViewModelAsCopy(Cuspa model) =>
        CreateEntryViewModel(EntryMode.Copy, model);

    [RelayCommand]
    private Task OpenEntryAsNewForBsAsync() => Task.Run(() => ViewState.OpenEntry(CreateEntryViewModel(EntryMode.New, new() { ForUnitType = UnitType.Battleship, })));

    private IDisposable CreateEntryViewModel(EntryMode mode, Cuspa model) =>
        new CuspaEntryViewModel(
            mode,
            model,
            App.GetRequiredService<IInsertPresentableUseCase<Cuspa, CuspaWebClient, IInsertPresenter<Cuspa>>>(),
            App.GetRequiredService<IUpdatePresentableUseCase<Cuspa, CuspaWebClient, IUpdatePresenter<Cuspa>>>(),
            App.GetRequiredService<IDeletePresentableUseCase<Cuspa, Cuspa, CuspaWebClient, IDeletePresenter<Cuspa>>>(),
            App.GetRequiredService<ICancelEntryUseCase<Cuspa>>(),
            App.GetRequiredService<IMapper<Cuspa, Cuspa>>(),
            App.GetRequiredService<CuspaKindInventory>(),
            App.GetRequiredService<BoostStatusInventory>(),
            App.GetRequiredService<TagInventory>());

}
