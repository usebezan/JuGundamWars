using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn._.Cuspas.Domain.Entities;

public class CuspaTagMap
{

    public int CuspaId { get; set; }
    public int TagId { get; set; }

    public Cuspa? Cuspa { get; set; }
    public Tag? Tag { get; set; }

}
