namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Byte
        /// </summary>
        /// <returns></returns>
        public byte ToByte()
        {
            if (raw_value > byte.MaxValue)
                return byte.MaxValue;
            else if (raw_value < byte.MinValue)
                return byte.MinValue;
            else
                return (byte)System.Math.Round(raw_value);
        }
    }
}