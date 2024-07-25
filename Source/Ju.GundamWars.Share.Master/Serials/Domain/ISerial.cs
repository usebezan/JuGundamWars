using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Serials.Domain;

public interface ISerial : IIdentifiable, IOrderable
{

    #region Primitives

    string Name { get; set; }

    #endregion

}
