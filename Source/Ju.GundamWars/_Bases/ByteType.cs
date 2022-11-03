using System;


namespace Ju.GundamWars
{

    public class ByteType<TEnum>
        where TEnum : Enum
    {

        public ByteType(TEnum type, byte value, string name) : this(type, value, name, "") { }

        public ByteType(TEnum type, byte value, string name, string iconKind)
        {
            Type = type;
            Value = value;
            Name = name;
            IconKind = iconKind;
        }


        public TEnum Type { get; }
        public byte Value { get; }
        public string Name { get; }
        public string IconKind { get; }

    }

}
