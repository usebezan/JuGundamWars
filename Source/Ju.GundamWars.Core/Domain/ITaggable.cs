using Ju.GundamWars.Domain.Tags;

namespace Ju.GundamWars.Domain;

public interface ITaggable
{
    GwObservableCollection<TagSubject> Tags { get; }
    void ReAddTags(IList<TagSubject> tags);
}
