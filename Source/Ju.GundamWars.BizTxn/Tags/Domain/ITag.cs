using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizTxn.Tags.Domain;

public interface ITag : IIdentify
{
    TagGroupType Group { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
