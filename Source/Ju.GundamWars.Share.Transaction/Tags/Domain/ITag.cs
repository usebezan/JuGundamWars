using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Tags.Domain;

public interface ITag : IIdentifiable, IOrderable
{

    #region Primitives

    TagGroupType TagGroupType { get; set; }
    string? Name { get; set; }

    #endregion

}
