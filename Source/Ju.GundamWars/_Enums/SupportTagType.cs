using Microsoft.Extensions.Options;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars
{

    public enum SupportTagType : byte
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


    public static class SupportTagTypeExtension
    {

        private static readonly string[] Texts = GetRequiredService<IOptions<UserSetting>>().Value.SupportTagTexts;


        public static SupportTagType ToSupportTagType(this byte self)
        {
            try { return (SupportTagType)self; } catch { return SupportTagType.Tag0; }
        }

        public static byte ToValue(this SupportTagType self) =>
            (byte)self;

        public static string ToText(this SupportTagType self)
        {
            try { return Texts[ToValue(self)]; } catch { return "Unknown"; }
        }

        public static string ToIconKind(this SupportTagType self) =>
            $"Numeric{self.ToValue()}Box";

    }

}
