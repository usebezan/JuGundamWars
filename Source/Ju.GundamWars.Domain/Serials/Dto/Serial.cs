namespace Ju.GundamWars.Domain.Serials.Dto;

public class Serial : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

}
