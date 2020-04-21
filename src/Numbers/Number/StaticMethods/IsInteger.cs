namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns true if the value passed is an integer, false otherwise.
        /// </summary>
        /// <param name="number">A numeric value.</param>
        /// <returns></returns>
        public static bool IsInteger(Number number) => System.Math.Floor(number.raw_value) == number.raw_value;
    }
}