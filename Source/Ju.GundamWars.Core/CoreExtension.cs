using Ju.GundamWars.Models.Entities;
using System;


namespace Ju.GundamWars
{

    public static class CoreExtension
    {

        public static int TryGetEnhancementValue<T>(this Dictionary<T, int> self, T key, int defaultValue = 0)
            where T : notnull
        {
            return self.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static int TryGetEnhancementValue<T1, T2>(this Dictionary<T1, (T2 _, int Value)> self, T1 key, int defaultValue = 0)
            where T1 : notnull
            where T2 : notnull
        {
            return self.TryGetValue(key, out var value) ? value.Value : defaultValue;
        }

        public static string GetTargetTypeText(this IEnhancement self) =>
            self.Target2Type == Target2Type.None ? self.Target2TypeText : $"{self.Target1TypeText}の{self.Target2TypeText}";

        public static bool IsValid(this IEnhancement self) =>
            self != null && self.Target1Type != Target1Type.Unknown && self.Target2Type != Target2Type.Unknown && self.CalcType != CalcType.Unknown;

        public static int Calc(this IEnhancement self, int multiplicationBase)
        {
            if (self.CalcType == CalcType.Addition)
            {
                return self.Value;
            }
            else if (self.CalcType == CalcType.Multiplication)
            {
                return multiplicationBase * self.Value / self.Fraction;
            }
            return 0;
        }

        public static int TryGetValue<T>(this Dictionary<T, int> self, T key, int defaultValue = 0)
            where T : notnull
        {
            return self.TryGetValue(key, out var value) ? value : defaultValue;
        }

    }

}
