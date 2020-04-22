namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a string containing a number represented either in exponential or fixed-point notation with a specified number of digits.
        /// </summary>
        /// <returns></returns>
        public string ToPrecision() => ToString();

        /// <summary>
        /// Returns a string containing a number represented either in exponential or fixed-point notation with a specified number of digits.
        /// </summary>
        /// <param name="precision">Number of significant digits. Must be in the range 1 - 21, inclusive.</param>
        /// <returns></returns>
        public string ToPrecision(Number precision)
        {
            string raw_value_string = raw_value.ToString();

            int decimalIndex;
            try
            {
                decimalIndex = raw_value_string.IndexOf('.');
            }
            catch(System.Exception)
            {
                decimalIndex = raw_value_string.Length;
            }

            if (decimalIndex < precision)
                return ToExponential(precision);
            else
                return ToFixed(precision - decimalIndex);
        }
    }
}