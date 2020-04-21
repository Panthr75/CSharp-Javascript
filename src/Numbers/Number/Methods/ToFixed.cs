namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a string representing a number in fixed-point notation.
        /// </summary>
        /// <param name="digits">Number of digits after the decimal point. Must be in the range 0 - 20, inclusive.</param>
        /// <returns></returns>
        public string ToFixed(int digits = 0)
        {
            if (digits < 0 || digits > 100)
                throw new System.ArgumentOutOfRangeException("digits", "must be between 0 and 100");
            else
            {
                double multiplier = System.Math.Pow(10, digits);
                return (System.Math.Round(multiplier * raw_value) / multiplier).ToString();
            }
        }
    }
}
