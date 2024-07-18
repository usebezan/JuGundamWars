using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Gateway;

public interface ITagGateway<T> : ISelectAllGateway<T>
    where T : class, ITag
{
    Task UpdateAllAsync(IList<T> tags);
}
