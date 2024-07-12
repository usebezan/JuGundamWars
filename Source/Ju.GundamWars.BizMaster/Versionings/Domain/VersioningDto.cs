using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public class VersioningDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;

    #endregion

}
