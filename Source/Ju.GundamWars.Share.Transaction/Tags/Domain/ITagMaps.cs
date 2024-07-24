using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Tags.Domain;

public interface ITagMaps<TTag> : IIdentify
{

    #region Navigations

    List<TTag> TagMaps { get; set; }

    #endregion

}
