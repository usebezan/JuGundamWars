namespace Ju.GundamWars.Domain.Versionings.Entities;

public class Versioning : IIdentify
{

    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;

}
