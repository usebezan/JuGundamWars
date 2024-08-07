using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;

namespace Ju.GundamWars.Cuspas.Domain.Service;

public class CuspaM2MMapper : CuspaMapperBase<Cuspa, CuspaStatus, Cuspa, CuspaStatus>
{
    public override Cuspa Map(Cuspa src, Cuspa dest) =>
        dest.Initialize(() =>
        {
            dest.IsChecked = src.IsChecked;
            MapCore(src, dest);
            dest.Tags.ReAddRange(src.Tags);
        });
}
