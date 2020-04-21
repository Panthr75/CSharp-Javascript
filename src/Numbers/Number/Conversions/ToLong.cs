namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Long
        /// </summary>
        /// <returns></returns>
        public long ToLong()
        {
            if (raw_value > long.MaxValue)
                return long.MaxValue;
            else if (raw_value < long.MinValue)
                return long.MinValue;
            else
                return (long)System.Math.Round(raw_value);
        }
    }
}