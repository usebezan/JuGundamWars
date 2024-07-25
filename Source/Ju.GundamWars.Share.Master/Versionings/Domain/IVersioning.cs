using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Versionings.Domain;

public interface IVersioning : IIdentifiable, IOrderable
{

    #region Primitives

    string Version { get; set; }

    #endregion

}
