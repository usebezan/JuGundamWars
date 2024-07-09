namespace Ju.GundamWars.Domain.Tags;

public interface ITag : IIdentify
{
    TagGroupType Group { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
