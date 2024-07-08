namespace Ju.GundamWars;

public class GwLoadException : Exception
{
    public GwLoadException() { }
    public GwLoadException(string message) : base(message) { }
    public GwLoadException(string message, Exception innerException) : base(message, innerException) { }
}
