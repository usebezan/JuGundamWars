namespace Ju.GundamWars.Domain;

[Flags]
public enum MessageAnswer : byte
{
    None = 0,
    Cancel = 1,
    Ok = 2,
    Yes = 4,
    No = 8,
    OkCancel = Ok + Cancel,
    YesNoCancel = Yes + No + Cancel,
}
