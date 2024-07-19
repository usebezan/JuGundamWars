using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Tags.Domain;

public interface ITag : IIdentify, IOrderable
{

    #region Primitives

    TagGroupType Group { get; set; }
    string Name { get; set; }

    #endregion

}
