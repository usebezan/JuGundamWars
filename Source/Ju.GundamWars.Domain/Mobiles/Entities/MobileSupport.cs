using Ju.GundamWars.Domain.Supports.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileSupport
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? SupportId { get; set; }

    public Mobile? Mobile { get; set; }
    public Support? Support { get; set; }

}
