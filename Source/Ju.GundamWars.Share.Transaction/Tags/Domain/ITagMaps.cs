namespace Ju.GundamWars.Share.Tags.Domain;

public interface ITagMaps<TTagLink>
{

    #region Navigations

    List<TTagLink> TagLinks { get; set; }

    #endregion

}
