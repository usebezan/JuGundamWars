using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Tags.Entities;

public class Tag : IIdentify
{

    public int Id { get; set; }
    public TagKindType Kind { get; set; }
    public string Name { get; set; } = null!;
    public int Order { get; set; }

}
