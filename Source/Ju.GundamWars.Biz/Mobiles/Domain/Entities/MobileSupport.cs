using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Mobiles.Domain.Entities;

public class MobileSupport
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? SupportId { get; set; }

    public Mobile? Mobile { get; set; }
    public Support? Support { get; set; }

}
