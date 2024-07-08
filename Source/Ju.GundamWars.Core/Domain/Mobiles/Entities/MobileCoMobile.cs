using Ju.GundamWars.Domain.CoMobiles.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileCoMobile
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? CoMobileId { get; set; }

    public Mobile? Mobile { get; set; }
    public CoMobile? CoMobile { get; set; }

}
