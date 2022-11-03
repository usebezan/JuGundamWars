using Microsoft.Extensions.Options;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars
{

    public enum MobileSuitTagType : byte
    {
        Tag0 = 0,
        Tag1,
        Tag2,
        Tag3,
        Tag4,
        Tag5,
        Tag6,
        Tag7,
        Tag8,
        Tag9,
    }


    public static class MobileSuitTagTypeExtension
    {

        private static readonly string[] Texts = GetRequiredService<IOptions<UserSetting>>().Value.MobileSuitTagTexts;


        public static MobileSuitTagType ToMobileSuitTagType(this byte self)
        {
            try { return (MobileSuitTagType)self; } catch { return MobileSuitTagType.Tag0; }
        }

        public static byte ToValue(this MobileSuitTagType self) =>
            (byte)self;

        public static string ToText(this MobileSuitTagType self)
        {
            try { return Texts[ToValue(self)]; } catch { return "Unknown"; }
        }

        public static string ToIconKind(this MobileSuitTagType self) =>
            $"Numeric{self.ToValue()}Box";

    }

}
