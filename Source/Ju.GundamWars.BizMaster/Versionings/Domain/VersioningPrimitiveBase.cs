namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public record VersioningPrimitiveBase : IVersioning
{

    #region Primitives

    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;

    #endregion

}
