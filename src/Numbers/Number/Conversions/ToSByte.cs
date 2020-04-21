namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Signed Byte
        /// </summary>
        /// <returns></returns>
        public sbyte ToSByte()
        {
            if (raw_value > sbyte.MaxValue)
                return sbyte.MaxValue;
            else if (raw_value < sbyte.MinValue)
                return sbyte.MinValue;
            else
                return (sbyte)System.Math.Round(raw_value);
        }
    }
}