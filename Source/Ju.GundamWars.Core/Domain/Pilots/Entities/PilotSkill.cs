namespace Ju.GundamWars.Domain.Pilots.Entities;

public class PilotSkill : IIdentify
{

    public int Id { get; set; }
    public string Group { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Order { get; set; }

}
