using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Share.Supports.Domain.Service;

namespace Ju.GundamWars.Supports.Domain.Service;

public class SupportM2MMapper : SupportMapperBase<Support, Support>
{
    public override Support Map(Support src, Support dest) =>
        dest.Initialize(() =>
        {
            dest.IsChecked = src.IsChecked;
            MapCore(src, dest);
            dest.Serial = src.Serial;
            dest.Tags.ReAddRange(src.Tags);
        });
}
