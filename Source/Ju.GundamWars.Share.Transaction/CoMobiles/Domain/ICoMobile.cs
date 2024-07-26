using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;

namespace Ju.GundamWars.Share.CoMobiles.Domain;

public interface ICoMobile : IIdentifiable
{

    #region Primitives

    string Name { get; set; }
    int SerialId { get; set; }
    RoleType RoleType { get; set; }
    byte Level { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }

    #endregion

}

public interface ICoMobile<TStatus, TCount> : ICoMobile
    where TStatus : ICoMobileStatus
    where TCount : ICoMobileUpgradedCount
{

    #region Primitive Models

    TStatus BasicStatus { get; }
    TStatus UpgradedStatus { get; }
    TCount UpgradedCount { get; }

    #endregion

}

public interface ICoMobile<TStatus, TCount, TTagLink> : ICoMobile<TStatus, TCount>, ITagMaps<TTagLink>
    where TStatus : ICoMobileStatus
    where TCount : ICoMobileUpgradedCount
    where TTagLink : ICoMobileTagLink
{
}
