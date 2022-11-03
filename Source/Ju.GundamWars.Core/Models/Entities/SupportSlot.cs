using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ju.GundamWars.Models.Entities
{

    public class SupportSlot : IEntity, IEnhancement
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public byte Type { get; set; }
        public byte Target1 { get; set; }
        public byte Target2 { get; set; }
        public byte Calc { get; set; }
        public int Value { get; set; }
        public int Fraction { get; set; }
        public long Order { get; set; }


        [NotMapped]
        public SlotType SlotType => Type.ToSlotType();

        [NotMapped]
        public Target1Type Target1Type => Target1.ToTarget1Type();

        [NotMapped]
        public string Target1TypeText => Target1Type.ToText();

        [NotMapped]
        public Target2Type Target2Type => Target2.ToTarget2Type();

        [NotMapped]
        public string Target2TypeText => Target2Type.ToText();

        [NotMapped]
        public string TargetTypeText => this.GetTargetTypeText();

        [NotMapped]
        public CalcType CalcType => Calc.ToCalcType();

        [NotMapped]
        public bool IsAttachable => SlotType == SlotType.Bonus || SlotType == SlotType.Normal;

    }

}
