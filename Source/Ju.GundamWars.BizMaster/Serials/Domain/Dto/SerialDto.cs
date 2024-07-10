using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Serials.Domain.Dto;

public class SerialDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
