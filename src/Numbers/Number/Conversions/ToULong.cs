namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Unsigned Long
        /// </summary>
        /// <returns></returns>
        public ulong ToULong()
        {
            if (raw_value > ulong.MaxValue)
                return ulong.MaxValue;
            else if (raw_value < ulong.MinValue)
                return ulong.MinValue;
            else
                return (ulong)System.Math.Round(raw_value);
        }
    }
}