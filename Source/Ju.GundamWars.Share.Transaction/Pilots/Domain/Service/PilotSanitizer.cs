using Ju.GundamWars.Commons.Domain.Service.Sanitization;

namespace Ju.GundamWars.Share.Pilots.Domain.Service;

// TODO: PilotSlotAbility 3つ固定
public class PilotSanitizer<T> : IInsertSanitizer<T>, IUpdateSanitizer<T>
    where T : IPilot
{
    public T Sanitize(T data)
    {
        data.Name = data.Name.Trim();
        data.Memo = data.Memo?.Trim();
        return data;
    }
}
