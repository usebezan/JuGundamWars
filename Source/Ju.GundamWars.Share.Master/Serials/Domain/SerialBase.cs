namespace Ju.GundamWars.Share.Serials.Domain;

public abstract record SerialBase : ISerial
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }

    #endregion

}
