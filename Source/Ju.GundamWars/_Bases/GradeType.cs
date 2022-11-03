using System;


namespace Ju.GundamWars
{

    public class GradeType
    {

        public GradeType(byte value, byte count, string colorName)
        {
            Value = value;
            Count = count;
            ColorName = colorName;
        }


        public byte Value { get; }
        public byte Count { get; }
        public string ColorName { get; }

    }

}
