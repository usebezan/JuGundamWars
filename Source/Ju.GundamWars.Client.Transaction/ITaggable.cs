using Ju.GundamWars.Client.Tags.Domain;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Client;

public interface ITaggable
{
    ObservableCollection<Tag> Tags { get; }
    void ReAddTags(IList<Tag> tags);
}
