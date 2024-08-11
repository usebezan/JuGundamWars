using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Cuspas.Infrastructure.WebClient;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaEntryViewModel : BizEntryViewModelBase2<Cuspa>
{

    public CuspaEntryViewModel(
        EntryMode mode,
        Cuspa model,
        IInsertPresentableUseCase<Cuspa, CuspaWebClient, IInsertPresenter<Cuspa>> insertClientUseCase,
        IUpdatePresentableUseCase<Cuspa, CuspaWebClient, IUpdatePresenter<Cuspa>> updateClientUseCase,
        IDeletePresentableUseCase<Cuspa, Cuspa, CuspaWebClient, IDeletePresenter<Cuspa>> deleteClientUseCase,
        ICancelEntryUseCase<Cuspa> cancelClientUseCase,
        IMapper<Cuspa, Cuspa> mapper,
        CuspaKindInventory cuspaKindInventory,
        BoostStatusInventory boostStatusInventory,
        TagInventory tagInventory)
        : base(mode, model, insertClientUseCase, updateClientUseCase, deleteClientUseCase, cancelClientUseCase, mapper, tagInventory)
    {
        CuspaKinds = new(cuspaKindInventory);
        BoostStatuses = new(boostStatusInventory) { Filter = FilterBoostStatus, };
    }


    public ListCollectionView CuspaKinds { get; }
    public ListCollectionView BoostStatuses { get; }


    private bool FilterBoostStatus(object obj)
    {
        if (obj is not BoostStatus item) return false;
        return item.Type.ForCuspa();
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCuspa();
    }

}
