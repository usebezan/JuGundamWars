using Ju.GundamWars.Core.Common.Domain;

namespace Ju.GundamWars.Core.Ju.GundamWars.Versionings.Dto;

public class Versioning : IIdentify
{
    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;
}
