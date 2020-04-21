namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Unsigned Integer
        /// </summary>
        /// <returns></returns>
        public uint ToUInt()
        {
            if (raw_value > uint.MaxValue)
                return uint.MaxValue;
            else if (raw_value < uint.MinValue)
                return uint.MinValue;
            else
                return (uint)System.Math.Round(raw_value);
        }
    }
}