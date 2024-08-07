using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;

namespace Ju.GundamWars.Pilots.Domain.Service;

public class PilotM2MMapper : PilotMapperBase<Pilot, PilotStatus, Pilot, PilotStatus>
{
    public override Pilot Map(Pilot src, Pilot dest) =>
        dest.Initialize(() =>
        {
            dest.IsChecked = src.IsChecked;
            MapCore(src, dest);
            //dest.Serial = src.Serial;
            //dest.Tags.ReAddRange(src.Tags);
        });
}
