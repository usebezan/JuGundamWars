using Ju.GundamWars.Domain.CoUnits.Dto;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileCoUnit
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? CoUnitId { get; set; }

    public Mobile? Mobile { get; set; }
    public CoUnit? CoUnit { get; set; }

}
