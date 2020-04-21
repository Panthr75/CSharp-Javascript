namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Integer
        /// </summary>
        /// <returns></returns>
        public int ToInt()
        {
            if (raw_value > int.MaxValue)
                return int.MaxValue;
            else if (raw_value < int.MinValue)
                return int.MinValue;
            else
                return (int)System.Math.Round(raw_value);
        }
    }
}