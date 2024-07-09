using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Roles.Domain;

public class RoleInventory : EnumObservableCollection<Role>
{
    public RoleInventory()
    {
        AddRange<RoleType>(e => e != RoleType.Unknown, e => new(e));
    }
}
/*
// 1
presenter.Increment(() => boostInventory.ReAddRange(GetEnumValues<BoostStatusType>(t => t != BoostStatusType.Unknown && t != BoostStatusType.Mobile && t != BoostStatusType.Pilot && t != BoostStatusType.Badge).Select(t => new Boost(t))));
// 2
presenter.Increment(() => categoryInventory.ReAddRange(GetEnumValues<CategoryType>(t => t != CategoryType.Unknown).Select(t => new Category(t))));
// 3
presenter.Increment(() => cuspaKindInventory.ReAddRange(GetEnumValues<CuspaKindType>(t => t != CuspaKindType.Unknown).Select(t => new CuspaKind(t))));
*/
