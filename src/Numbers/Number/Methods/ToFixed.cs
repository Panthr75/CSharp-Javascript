namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a string representing a number in fixed-point notation.
        /// </summary>
        /// <returns></returns>
        public string ToFixed() => ToFixed(new Number(0));

        /// <summary>
        /// Returns a string representing a number in fixed-point notation.
        /// </summary>
        /// <param name="digits">Number of digits after the decimal point. Must be in the range 0 - 20, inclusive.</param>
        /// <returns></returns>
        public string ToFixed(Number digits)
        {
            if (digits < 0 || digits > 100)
                throw new System.ArgumentOutOfRangeException("digits", "must be between 0 and 100");
            else
            {
                Number multiplier = Math.Pow(new Number(10), digits);
                return (Math.Round(multiplier * raw_value) / multiplier).ToString();
            }
        }
    }
}
