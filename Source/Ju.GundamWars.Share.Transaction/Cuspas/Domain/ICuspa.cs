using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Cuspas.Domain;

public interface ICuspa : IIdentifiable
{

    #region Primitives

    UnitType ForUnitType { get; set; }
    CuspaKindType CuspaKindType { get; set; }
    byte Level { get; set; }
    BoostStatusType BoostStatusType { get; set; }
    int BasicValue { get; set; }
    string? Memo { get; set; }

    #endregion

}

public interface ICuspa<TStatus> : ICuspa
    where TStatus : ICuspaStatus
{

    #region Primitive Models

    TStatus BonusStatus { get; }

    #endregion

}

public interface ICuspa<TStatus, TTagLink> : ICuspa<TStatus>, ITagMaps<TTagLink>
    where TStatus : ICuspaStatus
    where TTagLink : ICuspaTagLink
{
}
