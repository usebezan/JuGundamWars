using Ju.GundamWars.Domain.Tags.Model;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Biz;

public interface ITaggable
{
    ObservableCollection<TagSubject> Tags { get; }
    void ReAddTags(IList<TagSubject> tags);
}
