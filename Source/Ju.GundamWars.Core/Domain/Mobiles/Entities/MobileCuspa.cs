using Ju.GundamWars.Domain.Cuspas.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileCuspa
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int CuspaId { get; set; }

    public Mobile? Mobile { get; set; }
    public Cuspa? Cuspa { get; set; }

}
