namespace JavaScript
{
    public partial class Number
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Number nNum)
                return this == nNum;
            else if (obj is sbyte nSByte)
                return this == nSByte;
            else if (obj is byte nByte)
                return this == nByte;
            else if (obj is short nShort)
                return this == nShort;
            else if (obj is ushort nUShort)
                return this == nUShort;
            else if (obj is int nInt)
                return this == nInt;
            else if (obj is uint nUInt)
                return this == nUInt;
            else if (obj is long nLong)
                return this == nLong;
            else if (obj is ulong nULong)
                return this == nULong;
            else if (obj is float nFloat)
                return this == nFloat;
            else if (obj is double nDouble)
                return this == nDouble;
            else if (obj is decimal nDecimal)
                return this == nDecimal;
            else
                return false;
        }
    }
}