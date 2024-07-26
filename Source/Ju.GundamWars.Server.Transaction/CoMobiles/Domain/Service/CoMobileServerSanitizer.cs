using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileServerSanitizer : IInsertSanitizer<CoMobileEntity>, IUpdateSanitizer<CoMobileEntity>
{
    public CoMobileEntity Sanitize(CoMobileEntity data)
    {
        data.Name = data.Name.Trim();
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
