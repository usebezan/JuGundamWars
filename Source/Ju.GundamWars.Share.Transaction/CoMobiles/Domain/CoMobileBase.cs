using Ju.GundamWars.Share.Roles.Domain;

namespace Ju.GundamWars.Share.CoMobiles.Domain;

public abstract record CoMobileBase<TTagLink> : ICoMobile<CoMobileStatusRecord, CoMobileUpgradedCountRecord, TTagLink>
    where TTagLink : ICoMobileTagLink
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SerialId { get; set; } = 1;
    public RoleType RoleType { get; set; } = RoleType.Defensive;
    public byte Level { get; set; } = 60;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Primitive Models

    public CoMobileStatusRecord BasicStatus { get; } = new();
    public CoMobileStatusRecord UpgradedStatus { get; } = new();
    public CoMobileUpgradedCountRecord UpgradedCount { get; } = new();

    #endregion

    #region Navigations

    public List<TTagLink> TagLinks { get; set; } = [];

    #endregion

}
