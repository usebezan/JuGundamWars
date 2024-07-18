using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public interface IVersioning : IIdentify, IOrderable
{

    #region Primitives

    string Version { get; set; }

    #endregion

}
