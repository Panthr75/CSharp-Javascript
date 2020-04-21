namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Short
        /// </summary>
        /// <returns></returns>
        public short ToShort()
        {
            if (raw_value > short.MaxValue)
                return short.MaxValue;
            else if (raw_value < short.MinValue)
                return short.MinValue;
            else
                return (short)System.Math.Round(raw_value);
        }
    }
}