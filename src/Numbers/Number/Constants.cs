namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// A value that is not a number. In equality comparisons, NaN does not equal any value, including itself. To test whether a value is equivalent to NaN, use the isNaN function.
        /// </summary>
        public static Number NaN => new Number()
        {
            isNaN = true
        };

        /// <summary>
        /// A value greater than the largest number that can be represented in JavaScript. JavaScript displays POSITIVE_INFINITY values as infinity.
        /// </summary>
        public static Number POSITIVE_INFINITY => new Number()
        {
            isNaN = false,
            raw_value = double.PositiveInfinity
        };

        /// <summary>
        /// A value that is less than the largest negative number that can be represented in JavaScript. JavaScript displays NEGATIVE_INFINITY values as -infinity.
        /// </summary>
        public static Number NEGATIVE_INFINITY => new Number()
        {
            isNaN = false,
            raw_value = double.NegativeInfinity
        };

        /// <summary>
        /// The value of the smallest integer n such that n and n − 1 are both exactly representable as a Number value. The value of Number.MIN_SAFE_INTEGER is −9007199254740991 (−(2^53 − 1)).
        /// </summary>
        public static Number MIN_SAFE_INTEGER => new Number()
        {
            isNaN = false,
            raw_value = -9007199254740991
        };

        /// <summary>
        /// The value of the largest integer n such that n and n + 1 are both exactly representable as a Number value. The value of Number.MAX_SAFE_INTEGER is 9007199254740991 2^53 − 1.
        /// </summary>
        public static Number MAX_SAFE_INTEGER => new Number()
        {
            isNaN = false,
            raw_value = -9007199254740991
        };

        /// <summary>
        /// The value of Number.EPSILON is the difference between 1 and the smallest value greater than 1 that is representable as a Number value, which is approximately: 2.2204460492503130808472633361816 x 10‍−‍16.
        /// </summary>
        public static Number EPSILON => new Number()
        {
            isNaN = false,
            raw_value = 2.2204460492503130808472633361816e-16
        };

        /// <summary>
        /// The largest number that can be represented in JavaScript. Equal to approximately 1.79E+308.
        /// </summary>
        public static Number MAX_VALUE => new Number()
        {
            isNaN = false,
            raw_value = double.MaxValue
        };

        /// <summary>
        /// The closest number to zero that can be represented in JavaScript. Equal to approximately 5.00E-324.
        /// </summary>
        public static Number MIN_VALUE => new Number()
        {
            isNaN = false,
            raw_value = double.Epsilon
        };
    }
}