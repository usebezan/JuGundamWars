namespace Ju.GundamWars.Domain.Systems.Entities;

public class Serial : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Order { get; set; }

}
