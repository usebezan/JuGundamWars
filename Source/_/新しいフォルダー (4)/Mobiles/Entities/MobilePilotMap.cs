using Ju.GundamWars.Domain.Pilots.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobilePilotMap
{

    public int MobileId { get; set; }
    public int PilotId { get; set; }

    public Mobile? Mobile { get; set; }
    public Pilot? Pilot { get; set; }

}
