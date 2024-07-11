using Ju.GundamWars.BizTxn.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;

public class CuspaTagMapDto
{

    #region Primitives

    public int CuspaId { get; set; }
    public int TagId { get; set; }

    #endregion

    #region Navigations

    public CuspaDto? Cuspa { get; set; }
    public TagDto? Tag { get; set; }

    #endregion

}
