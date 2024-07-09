namespace Ju.GundamWars.Domain.Pilots.Entities;

public class PilotSkill : IIdentify
{

    public int Id { get; set; }
    public string Group { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

}
