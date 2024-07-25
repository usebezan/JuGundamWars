using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class InsertCoMobileSanitizer<T> : IInsertSanitizer<T>
    where T : ICoMobile
{
    public T Sanitize(T data)
    {
        data.Name = data.Name.Trim();
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
