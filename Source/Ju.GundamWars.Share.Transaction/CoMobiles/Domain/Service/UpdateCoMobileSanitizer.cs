using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Share.CoMobiles.Domain.Service;

public class UpdateCoMobileSanitizer<T> : IUpdateSanitizer<T>
    where T : ICoMobile
{
    public T Sanitize(T data)
    {
        data.Name = data.Name.Trim();
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
