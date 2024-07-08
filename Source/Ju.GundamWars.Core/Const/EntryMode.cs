namespace Ju.GundamWars.Const;

public enum EntryMode : byte
{
    None = 0,
    New,
    Edit,
    Copy,
}

public static class EntryModeExtension
{

    public static byte ToValue(this EntryMode self) =>
        (byte)self;

    public static string ToText(this EntryMode self) =>
        self switch
        {
            EntryMode.New => "New",
            EntryMode.Edit => "Edit",
            EntryMode.Copy => "Copy",
            _ => string.Empty,
        };

}
