using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Share.Supports.Domain.Service;

public class SupportSanitizer<T> : IInsertSanitizer<T>, IUpdateSanitizer<T>
    where T : ISupport
{
    public T Sanitize(T data)
    {
        data.Name = data.Name.Trim();
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
