using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.Cuspas.Entities;

public class CuspaTagMap
{

    public int CuspaId { get; set; }
    public int TagId { get; set; }

    public Cuspa? Cuspa { get; set; }
    public Tag? Tag { get; set; }

}
