using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Server.Cuspas.Domain.Service;

public class UpdateCuspaServerSanitizer : IUpdateSanitizer<CuspaEntity>
{
    public CuspaEntity Sanitize(CuspaEntity data)
    {
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
