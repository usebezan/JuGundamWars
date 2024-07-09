using Ju.GundamWars.Domain.Tags.Dto;

namespace Ju.GundamWars.Domain.CoUnits.Dto;

public class CoUnitTagMap
{

    public int CoUnitId { get; set; }
    public int TagId { get; set; }

    public CoUnit? CoUnit { get; set; }
    public Tag? Tag { get; set; }

}
