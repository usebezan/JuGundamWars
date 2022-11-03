using System;


namespace Ju.GundamWars.Models.Entities
{

    public class Enhancement : IEnhancement
    {

        public Enhancement(IEnhancement enhancement)
            : this(enhancement.Target1Type, enhancement.Target2Type, enhancement.CalcType, enhancement.Value, enhancement.Fraction)
        {
        }

        public Enhancement(IEnhancement enhancement, Target2Type target2Type)
            : this(enhancement.Target1Type, target2Type, enhancement.CalcType, enhancement.Value, enhancement.Fraction)
        {
        }

        public Enhancement(IEnhancement enhancement, int value)
            : this(enhancement.Target1Type, enhancement.Target2Type, enhancement.CalcType, value, enhancement.Fraction)
        {
        }

        public Enhancement(Target1Type target1Type, Target2Type target2Type, CalcType calcType, int value, int fraction)
        {
            Target1Type = target1Type;
            Target2Type = target2Type;
            CalcType = calcType;
            Value = value;
            Fraction = fraction;
        }


        public Target1Type Target1Type { get; }
        public Target2Type Target2Type { get; }
        public CalcType CalcType { get; }
        public int Value { get; }
        public int Fraction { get; }

        public string Target1TypeText => Target1Type.ToText();
        public string Target2TypeText => Target2Type.ToText();
        public string TargetTypeText => this.GetTargetTypeText();

    }

}
