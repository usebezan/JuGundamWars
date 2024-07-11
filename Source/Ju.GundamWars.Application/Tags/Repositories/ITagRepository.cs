namespace Ju.GundamWars.Application.Tags.Repositories;

public interface ITagRepository : IReadOnlyRepository<Tag>
{
    Task UpdateAsync(IList<Tag> tags);
}
