using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Biz.Versionings.Domain.Dto;

public class Versioning : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;

    #endregion

}
