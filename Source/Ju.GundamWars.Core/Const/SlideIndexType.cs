namespace Ju.GundamWars.Const;

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
    Unknown = 255,
}

public static class SlideIndexTypeExtension
{

    public static byte ToValue(this SlideIndexType self) =>
        (byte)self;

}
