using Ju.GundamWars.Core.Common.Domain;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.TagGroups;

namespace Ju.GundamWars.Tags.Domain;

public interface ITag : IIdentify
{
    TagGroupType Group { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
