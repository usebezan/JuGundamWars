namespace Ju.GundamWars.Commons.Domain;

public enum PageIndexType : byte
{
    List = 0,
    Entry,
    Unknown = byte.MaxValue,
}

public static class PageIndexTypeExtension
{

    public static byte ToValue(this PageIndexType self) =>
        (byte)self;

}
