using System;


namespace Ju.GundamWars.Models.Entities
{

    public interface IEnhancement
    {

        public Target1Type Target1Type { get; }
        public Target2Type Target2Type { get; }
        public CalcType CalcType { get; }
        public int Value { get; }
        public int Fraction { get; }

        public string Target1TypeText { get; }
        public string Target2TypeText { get; }
        public string TargetTypeText { get; }

    }

}
