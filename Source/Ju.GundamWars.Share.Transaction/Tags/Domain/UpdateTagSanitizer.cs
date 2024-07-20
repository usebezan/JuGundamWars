using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Share.Tags.Domain;

public class UpdateTagSanitizer<T> : IUpdateSanitizer<T>
    where T : ITag
{
    public T Sanitize(T data)
    {
        data.Name = data.Name?.Trim();
        return data;
    }
}
