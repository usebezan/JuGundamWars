using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Application.Systems;

public class LoadConstDataUseCaseInteractor(
    IBoostInventory boostInventory,
    ICategoryInventory categoryInventory,
    ICuspaKindInventory cuspaKindInventory,
    IGradeInventory gradeInventory,
    IHasAceInventory hasAceInventory,
    IMobileKindInventory mobileKindInventory,
    IPositionInventory positionInventory,
    IRoleInventory roleInventory,
    ITerrainInventory terrainInventory,
    IProgressPresenter presenter)
    : ILoadConstDataUseCase
{

    public int ProgressCount => 9;


    private IEnumerable<TType> GetEnumValues<TType>(Func<TType, bool> predicate)
        where TType : Enum =>
        Enum.GetValues(typeof(TType)).Cast<TType>().Where(predicate);

    public void Handle()
    {
        presenter.ShowMessage("Loading data...");

        // 1
        presenter.Increment(() => boostInventory.ReAddRange(GetEnumValues<BoostStatusType>(t => t != BoostStatusType.Unknown && t != BoostStatusType.Mobile && t != BoostStatusType.Pilot && t != BoostStatusType.Badge).Select(t => new Boost(t))));
        // 2
        presenter.Increment(() => categoryInventory.ReAddRange(GetEnumValues<CategoryType>(t => t != CategoryType.Unknown).Select(t => new Category(t))));
        // 3
        presenter.Increment(() => cuspaKindInventory.ReAddRange(GetEnumValues<CuspaKindType>(t => t != CuspaKindType.Unknown).Select(t => new CuspaKind(t))));
        // 4
        presenter.Increment(() => gradeInventory.ReAddRange(GetEnumValues<GradeType>(t => t != GradeType.Unknown).Select(t => new Grade(t))));
        // 5
        presenter.Increment(() => hasAceInventory.ReAddRange(GetEnumValues<AceImplType>(t => t != AceImplType.Unknown).Select(t => new HasAce(t))));
        // 6
        presenter.Increment(() => mobileKindInventory.ReAddRange(GetEnumValues<MobileKindType>(t => t != MobileKindType.Unknown).Select(t => new MobileKind(t))));
        // 7
        presenter.Increment(() => positionInventory.ReAddRange(GetEnumValues<PositionType>(t => t != PositionType.Unknown).Select(t => new Position(t))));
        // 8
        presenter.Increment(() => roleInventory.ReAddRange(GetEnumValues<RoleType>(t => t != RoleType.Unknown).Select(t => new Role(t))));
        // 9
        presenter.Increment(() => terrainInventory.ReAddRange(GetEnumValues<TerrainType>(t => t != TerrainType.Unknown).Select(t => new Terrain(t))));
    }

}
