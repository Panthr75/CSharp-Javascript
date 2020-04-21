namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts a string to a floating-point number.
        /// </summary>
        /// <param name="s">A string that contains a floating-point number.</param>
        /// <returns></returns>
        public static Number ParseFloat(string s) => new Number(s);
    }
}