using Ju.GundamWars.BizTxn.Tags.Domain.Model;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.BizTxn;

public interface ITaggable
{
    ObservableCollection<Tag> Tags { get; }
    void ReAddTags(IList<Tag> tags);
}
