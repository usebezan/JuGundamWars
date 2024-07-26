using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Share.Cuspas.Domain.Service;

public class CuspaSanitizer<T> : IInsertSanitizer<T>, IUpdateSanitizer<T>
    where T : ICuspa
{
    public T Sanitize(T data)
    {
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
