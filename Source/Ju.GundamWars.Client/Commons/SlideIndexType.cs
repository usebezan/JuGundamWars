namespace Ju.GundamWars.Client.Commons;

public enum SlideIndexType : byte
{
    Progress = 0,
    Main,
    MobileEntry,
    PilotEntry,
    CuspaEntry,
    SupportEntry,
    CoMobileEntry,
    PairSelection,
    PilotSelection,
    NCuspaSelection,
    SCuspaSelection,
    SupportSelection,
    CoMobileSelection,
    Unknown = byte.MaxValue,
}

public static class SlideIndexTypeExtension
{

    public static byte ToValue(this SlideIndexType self) =>
        (byte)self;

}
