using Ju.GundamWars.Cuspas.Domain.Entities;

namespace Ju.GundamWars.Mobiles.Domain.Entities;

public class MobileCuspa
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int CuspaId { get; set; }

    public Mobile? Mobile { get; set; }
    public Cuspa? Cuspa { get; set; }

}
