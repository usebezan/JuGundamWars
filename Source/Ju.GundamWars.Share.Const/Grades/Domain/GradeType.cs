namespace Ju.GundamWars.Share.Grades.Domain;

public enum GradeType : byte
{
    Grade1 = 1,
    Grade2,
    Grade3,
    Grade4,
    Grade5,
    Grade6,
    SGrade1,
    SGrade2,
    SGrade3,
    SGrade4,
    SGrade5,
    Unknown = byte.MaxValue,
}

public static class GradeTypeExtension
{

    public static GradeType ToGradeType(this byte self)
    {
        try { return (GradeType)self; } catch { return GradeType.Unknown; }
    }

    public static byte ToValue(this GradeType self) =>
        (byte)self;

    public static string ToText(this GradeType self) =>
        self switch
        {
            GradeType.Grade1 => "1",
            GradeType.Grade2 => "2",
            GradeType.Grade3 => "3",
            GradeType.Grade4 => "4",
            GradeType.Grade5 => "5",
            GradeType.Grade6 => "6",
            GradeType.SGrade1 => "1",
            GradeType.SGrade2 => "2",
            GradeType.SGrade3 => "3",
            GradeType.SGrade4 => "4",
            GradeType.SGrade5 => "5",
            _ => GwText.Unknown,
        };

    public static string ToColor(this GradeType self) =>
        self switch
        {
            GradeType.Grade1 => "Goldenrod",
            GradeType.Grade2 => "Goldenrod",
            GradeType.Grade3 => "Goldenrod",
            GradeType.Grade4 => "Goldenrod",
            GradeType.Grade5 => "Goldenrod",
            GradeType.Grade6 => "Goldenrod",
            GradeType.SGrade1 => "MediumPurple",
            GradeType.SGrade2 => "MediumPurple",
            GradeType.SGrade3 => "MediumPurple",
            GradeType.SGrade4 => "MediumPurple",
            GradeType.SGrade5 => "MediumPurple",
            _ => "White",
        };

    public static bool ForMobile(this GradeType self) =>
        self != GradeType.Unknown;

    public static bool ForMobileInitial(this GradeType self) =>
        self switch
        {
            GradeType.Grade1 => true,
            GradeType.Grade2 => true,
            GradeType.Grade3 => true,
            GradeType.Grade4 => true,
            GradeType.Grade5 => true,
            _ => false,
        };

    public static bool ForPilot(this GradeType self) =>
        self switch
        {
            GradeType.Grade1 => true,
            GradeType.Grade2 => true,
            GradeType.Grade3 => true,
            GradeType.Grade4 => true,
            GradeType.Grade5 => true,
            GradeType.Grade6 => true,
            _ => false,
        };

    public static bool ForSupport(this GradeType self) =>
        self switch
        {
            GradeType.Grade1 => true,
            GradeType.Grade2 => true,
            GradeType.Grade3 => true,
            _ => false,
        };

}
