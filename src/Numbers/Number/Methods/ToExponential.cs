namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a string containing a number represented in exponential notation.
        /// </summary>
        /// <returns></returns>
        public string ToExponential()
        {
            string raw_value_string = raw_value.ToString();
            int decimalIndex;
            try
            {
                decimalIndex = raw_value_string.IndexOf('.') - 1;
            }
            catch(System.Exception)
            {
                decimalIndex = -2;
            }

            if (decimalIndex == -2)
                decimalIndex = raw_value_string.Length - 1;

            string raw_str = raw_value_string.Replace(".", "");
            string str = new System.Text.RegularExpressions.Regex(@"^0+").Replace(raw_str, "");

            int eVal = raw_str.Length - str.Length + decimalIndex;

            return $"{str[0]}.{str.Substring(1)}e{(eVal < 0 ? "-" : "+")}{eVal}";
        }

        /// <summary>
        /// Returns a string containing a number represented in exponential notation.
        /// </summary>
        /// <param name="fractionDigits">Number of digits after the decimal point.</param>
        /// <returns></returns>
        public string ToExponential(Number fractionDigits)
        {
            string raw_value_string = raw_value.ToString();
            int decimalIndex;
            try
            {
                decimalIndex = raw_value_string.IndexOf('.') - 1;
            }
            catch (System.Exception)
            {
                decimalIndex = -2;
            }

            if (decimalIndex == -2)
                decimalIndex = raw_value_string.Length - 1;

            string raw_str = raw_value_string.Replace(".", "");
            string str = new System.Text.RegularExpressions.Regex(@"^0+").Replace(raw_str, "");

            int eVal = raw_str.Length - str.Length + decimalIndex;
            string digits = $"{str.Substring(1)}";
            for (int index = 0, length = (fractionDigits - digits.Length).ToInt(); index < length; index++)
                digits += "0";
            digits = digits.Substring(0, fractionDigits.ToInt());

            return $"{str[0]}{(digits.Length > 0 ? $".{digits}" : "")}e{(eVal < 0 ? "-" : "+")}{eVal}";
        }
    }
}