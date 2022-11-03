using System;


namespace Ju.GundamWars
{

    public class IntType<TEnum>
        where TEnum : Enum
    {

        public IntType(TEnum type, int value, string name) : this(type, value, name, "") { }

        public IntType(TEnum type, int value, string name, string iconKind)
        {
            Type = type;
            Value = value;
            Name = name;
            IconKind = iconKind;
        }


        public TEnum Type { get; }
        public int Value { get; }
        public string Name { get; }
        public string IconKind { get; }

    }

}
