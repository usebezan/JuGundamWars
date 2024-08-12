using Ju.GundamWars.Share.CoMobiles.Domain.Service;

namespace Ju.GundamWars.Client.CoMobiles.Domain.Service;

public class CoMobileM2MMapper : CoMobileMapperBase<CoMobile, CoMobileStatus, CoMobileUpgradedCount, CoMobile, CoMobileStatus, CoMobileUpgradedCount>
{
    public override CoMobile Map(CoMobile src, CoMobile dest) =>
        dest.Initialize(() =>
        {
            dest.IsChecked = src.IsChecked;
            MapCore(src, dest);
            dest.Tags.ReAddRange(src.Tags);
            dest.Serial = src.Serial;
            dest.Role = src.Role;
        });
}
