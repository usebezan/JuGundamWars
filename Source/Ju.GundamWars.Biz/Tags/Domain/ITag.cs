using Ju.GundamWars.BizMaster.TagGroups.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Biz.Tags.Domain;

public interface ITag : IIdentify
{
    TagGroupType Group { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
