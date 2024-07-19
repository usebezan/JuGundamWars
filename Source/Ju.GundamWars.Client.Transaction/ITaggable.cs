using Ju.GundamWars.BizTxn.Tags.Domain.Model;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Client;

public interface ITaggable
{
    ObservableCollection<Tag> Tags { get; }
    void ReAddTags(IList<Tag> tags);
}
