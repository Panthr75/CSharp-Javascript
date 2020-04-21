namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Unsigned Short
        /// </summary>
        /// <returns></returns>
        public ushort ToUShort()
        {
            if (raw_value > ushort.MaxValue)
                return ushort.MaxValue;
            else if (raw_value < ushort.MinValue)
                return ushort.MinValue;
            else
                return (ushort)System.Math.Round(raw_value);
        }
    }
}