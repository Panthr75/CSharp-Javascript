namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a Boolean value that indicates whether a value is the reserved value NaN (not a number). Unlike the global IsNaN(), Number.IsNaN() doesn't forcefully convert the parameter to a number. Only values of the type number, that are also NaN, result in true.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNaN(Number number) => number.isNaN;
    }
}