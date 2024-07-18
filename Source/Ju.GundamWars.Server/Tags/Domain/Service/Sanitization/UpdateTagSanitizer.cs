using Ju.GundamWars.BizTxn.Tags.Domain.Entity;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Server.Tags.Domain.Service.Sanitization;

public class UpdateTagSanitizer : IUpdateSanitizer<TagEntity>
{
    public TagEntity Sanitize(TagEntity data)
    {
        data.Name = data.Name.Trim();
        return data;
    }
}
