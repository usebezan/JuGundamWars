using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Application.Tags.Repositories;

public interface ITagRepository : IReadOnlyRepository<Tag>
{
    Task UpdateAsync(IList<Tag> tags);
}
