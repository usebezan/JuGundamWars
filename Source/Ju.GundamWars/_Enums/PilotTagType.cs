using Microsoft.Extensions.Options;
using System;
using static Ju.GundamWars.App;


namespace Ju.GundamWars
{

    public enum PilotTagType : byte
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


    public static class PilotTagTypeExtension
    {

        private static readonly string[] Texts = GetRequiredService<IOptions<UserSetting>>().Value.PilotTagTexts;


        public static PilotTagType ToPilotTagType(this byte self)
        {
            try { return (PilotTagType)self; } catch { return PilotTagType.Tag0; }
        }

        public static byte ToValue(this PilotTagType self) =>
            (byte)self;

        public static string ToText(this PilotTagType self)
        {
            try { return Texts[ToValue(self)]; } catch { return "Unknown"; }
        }

        public static string ToIconKind(this PilotTagType self) =>
            $"Numeric{self.ToValue()}Box";

    }

}
