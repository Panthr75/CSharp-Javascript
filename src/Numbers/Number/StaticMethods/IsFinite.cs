namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns true if passed value is finite. Unlike the global IsFinite, Number.IsFinite doesn't forcibly convert the parameter to a number. Only finite values of the type number, result in true.
        /// </summary>
        /// <param name="number">A numeric value.</param>
        /// <returns></returns>
        public static bool IsFinite(Number number)
        {
            return number.raw_value == double.PositiveInfinity || number.raw_value == double.NegativeInfinity;
        }
    }
}