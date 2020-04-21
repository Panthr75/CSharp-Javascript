namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns true if the value passed is a safe integer.
        /// </summary>
        /// <param name="number">A numeric value.</param>
        /// <returns></returns>
        public static bool IsSafeInteger(Number number)
        {
            if (IsInteger(number))
                return number < MAX_SAFE_INTEGER && number > MIN_SAFE_INTEGER;
            else
                return false;
        }
    }
}