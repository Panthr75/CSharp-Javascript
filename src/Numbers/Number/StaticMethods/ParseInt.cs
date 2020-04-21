namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts A string to an integer.
        /// </summary>
        /// <param name="s">A string to convert into a number.</param>
        /// <returns></returns>
        public static Number ParseInt(string s) => new Number(s.Split('.')[0]);

        /// <summary>
        /// Converts A string to an integer.
        /// </summary>
        /// <param name="s">A string to convert into a number.</param>
        /// <param name="radix">A value between 2 and 36 that specifies the base of the number in numString. If this argument is not supplied, strings with a prefix of '0x' are considered hexadecimal. All other strings are considered decimal.</param>
        /// <returns></returns>
        public static Number ParseInt(string s, int radix)
        {
            if (radix < 2 || radix > 36)
                return NaN;

            //TODO: Implement parsing bases that are not 2, 8, 10, or 16 [Bases System.Convert.ToInt64 can't handle]

            return new Number(System.Convert.ToInt64(s.Split('.')[0], radix));
        }
    }
}