namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Returns a string representation of an object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (isNaN)
                return "NaN";
            if (raw_value == POSITIVE_INFINITY)
                return "Infinity";
            if (raw_value == NEGATIVE_INFINITY)
                return "-Infinity";

            return raw_value.ToString()
        }

        /// <summary>
        /// Returns a string representation of an object.
        /// </summary>
        /// <param name="radix">Specifies a radix for converting numeric values to strings. This value is only used for numbers.</param>
        /// <returns></returns>
        public string ToString(int radix)
        {
            Collections.Array<string> sections = new Collections.Array<string>(ToString().Split('.'));

            for (int index = 0, length = sections.Length; index < length; index++)
            {
                sections[index] = System.Convert.ToString(long.Parse(sections[index]), radix);
            }

            return sections.Join(".");
        }
    }
}