namespace Ju.GundamWars.Domain.System;

public enum SlideIndexType : byte
{
    Progress = 0,
    Main,
    MobileEntry,
    PilotEntry,
    CuspaEntry,
    SupportEntry,
    CoUnitEntry,
    PairSelection,
    PilotSelection,
    NCuspaSelection,
    SCuspaSelection,
    SupportSelection,
    CoUnitSelection,
    Unknown = 255,
}

public static class SlideIndexTypeExtension
{

    public static byte ToValue(this SlideIndexType self) =>
        (byte)self;

}
