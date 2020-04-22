namespace JavaScript
{
    /// <summary>
    /// An intrinsic object that provides basic mathematics functionality and constants.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// The mathematical constant e. This is Euler's number, the base of natural logarithms.
        /// </summary>
        public static Number E => new Number(2.718281828459045);

        /// <summary>
        /// The natural logarithm of 10.
        /// </summary>
        public static Number LN10 => new Number(2.302585092994046);

        /// <summary>
        /// The natural logarithm of 2.
        /// </summary>
        public static Number LN2 => new Number(0.6931471805599453);

        /// <summary>
        /// The base-10 logarithm of e.
        /// </summary>
        public static Number LOG10E => new Number(0.4342944819032518);

        /// <summary>
        /// The base-2 logarithm of e.
        /// </summary>
        public static Number LOG2E => new Number(1.4426950408889634);

        /// <summary>
        /// Pi. This is the ratio of the circumference of a circle to its diameter.
        /// </summary>
        public static Number PI => new Number(3.141592653589793);

        /// <summary>
        /// The square root of 0.5, or, equivalently, one divided by the square root of 2.
        /// </summary>
        public static Number SQRT1_2 => new Number(0.7071067811865476);

        /// <summary>
        /// The square root of 2.
        /// </summary>
        public static Number SQRT2 => new Number(1.4142135623730951);

        /// <summary>
        /// Returns the absolute value of a number (the value without regard to whether it is positive or negative). For example, the absolute value of -5 is the same as the absolute value of 5.
        /// </summary>
        /// <param name="x">A numeric expression for which the absolute value is needed.</param>
        /// <returns></returns>
        public static Number Abs(Number x)
        {
            if (x < 0)
                return -x;
            else
                return x;
        }

        /// <summary>
        /// Returns the arc cosine (or inverse cosine) of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Acos(Number x)
        {
            return new Number(System.Math.Acos(x.ToDouble()));
        }

        /// <summary>
        /// Returns the inverse hyperbolic cosine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Acosh(Number x)
        {
            return Log(x + Sqrt(x + 1) * Sqrt(x - 1));
        }

        /// <summary>
        /// Returns the arcsine of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Asin(Number x)
        {
            return new Number(System.Math.Asin(x.ToDouble()));
        }

        /// <summary>
        /// Returns the inverse hyperbolic sine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Asinh(Number x)
        {
            return Log(x + Sqrt(1 + (x * x)));
        }

        /// <summary>
        /// Returns the arctangent of a number.
        /// </summary>
        /// <param name="x">A numeric expression for which the arctangent is needed.</param>
        /// <returns></returns>
        public static Number Atan(Number x)
        {
            return new Number(System.Math.Atan(x.ToDouble()));
        }

        /// <summary>
        /// Returns the angle (in radians) from the X axis to a point.
        /// </summary>
        /// <param name="y">A numeric expression representing the cartesian y-coordinate.</param>
        /// <param name="x">A numeric expression representing the cartesian x-coordinate.</param>
        /// <returns></returns>
        public static Number Atan2(Number y, Number x)
        {
            return new Number(System.Math.Atan2(y.ToDouble(), x.ToDouble()));
        }

        /// <summary>
        /// Returns the inverse hyperbolic tangent of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Atanh(Number x)
        {
            return 0.5 * (Log(1 + x) - Log(1 - x));
        }

        /// <summary>
        /// Returns an implementation-dependent approximation to the cube root of number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Cbrt(Number x)
        {
            return Pow(x, new Number(1d / 3d));
        }

        /// <summary>
        /// Returns the smallest integer greater than or equal to its numeric argument.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Ceil(Number x)
        {
            return new Number(System.Math.Ceiling(x.ToDouble()));
        }

        /// <summary>
        /// Returns the number of leading zero bits in the 32-bit binary representation of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        [System.Obsolete("To be implemented")]
        public static Number Clz32(Number x)
        {
            return null;
        }

        /// <summary>
        /// Returns the cosine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Cos(Number x)
        {
            return new Number(System.Math.Cos(x.ToDouble()));
        }

        /// <summary>
        /// Returns the hyperbolic cosine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Cosh(Number x)
        {
            return new Number(System.Math.Cosh(x.ToDouble()));
        }

        /// <summary>
        /// Returns e (the base of natural logarithms) raised to a power.
        /// </summary>
        /// <param name="x">A numeric expression representing the power of e.</param>
        /// <returns></returns>
        public static Number Exp(Number x)
        {
            return new Number(System.Math.Exp(x.ToDouble()));
        }

        /// <summary>
        /// Returns the result of (e^x - 1), which is an implementation-dependent approximation to subtracting 1 from the exponential function of x (e raised to the power of x, where e is the base of the natural logarithms).
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Expm1(Number x)
        {
            return Exp(x) - 1;
        }

        /// <summary>
        /// Returns the greatest integer less than or equal to its numeric argument.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Floor(Number x)
        {
            return new Number(System.Math.Floor(x.ToDouble()));
        }

        /// <summary>
        /// Returns the nearest single precision float representation of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        [System.Obsolete("To be implemented")]
        public static Number Fround(Number x)
        {
            return null;
        }

        /// <summary>
        /// Returns the square root of the sum of squares of its arguments.
        /// </summary>
        /// <param name="values">Values to compute the square root for. If no arguments are passed, the result is +0. If there is only one argument, the result is the absolute value. If any argument is +Infinity or -Infinity, the result is +Infinity. If any argument is NaN, the result is NaN. If all arguments are either +0 or −0, the result is +0.</param>
        /// <returns></returns>
        public static Number Hypot(params Number[] values)
        {
            if (values.Length == 0)
                return new Number();
            else if (values.Length == 1)
            {
                Number num = values[0];

                if (!Number.IsFinite(num))
                    return Number.POSITIVE_INFINITY;
                else if (!Number.IsNaN(num))
                    return Number.NaN;
                else
                    return Abs(num);
            }

            Number total = new Number();
            for(int index = 0, length = values.Length; index < length; index++)
            {
                Number num = values[index];
                if (!Number.IsFinite(num))
                    return Number.POSITIVE_INFINITY;
                else if (!Number.IsNaN(num))
                    return Number.NaN;
                total += num;
            }

            return Sqrt(total);
        }

        /// <summary>
        /// Returns the result of 32-bit multiplication of two numbers.
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns></returns>
        public static Number Imul(Number x, Number y)
        {
            return new Number(System.Math.BigMul(x.ToInt(), y.ToInt()));
        }

        /// <summary>
        /// Returns the natural logarithm (base e) of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Log(Number x)
        {
            return new Number(System.Math.Log(x.ToDouble()));
        }

        /// <summary>
        /// Returns the base 10 logarithm of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Log10(Number x)
        {
            return new Number(System.Math.Log10(x.ToDouble()));
        }

        /// <summary>
        /// Returns the natural logarithm of 1 + x.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Log1p(Number x)
        {
            return Log(1 + x);
        }

        /// <summary>
        /// Returns the base 2 logarithm of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Log2(Number x)
        {
            return new Number(System.Math.Log(x.ToDouble(), 2));
        }

        /// <summary>
        /// Returns the larger of a set of supplied numeric expressions.
        /// </summary>
        /// <param name="values">Numeric expressions to be evaluated.</param>
        /// <returns></returns>
        public static Number Max(params Number[] values)
        {
            if (values.Length == 0)
                return Number.NEGATIVE_INFINITY;
            else if (values.Length == 1)
                return values[0];

            Number max = values[0];

            for (long index = 0, length = values.LongLength; index < length; index++)
            {
                Number num = values[index];

                if (num > max)
                    max = num;
            }

            return max;
        }

        /// <summary>
        /// Returns the larger of a set of supplied numeric expressions.
        /// </summary>
        /// <param name="values">Numeric expressions to be evaluated.</param>
        /// <returns></returns>
        public static Number Min(params Number[] values)
        {
            if (values.Length == 0)
                return Number.POSITIVE_INFINITY;
            else if (values.Length == 1)
                return values[0];

            Number min = values[0];

            for (long index = 0, length = values.LongLength; index < length; index++)
            {
                Number num = values[index];

                if (num < min)
                    min = num;
            }

            return min;
        }

        /// <summary>
        /// Returns the value of a base expression taken to a specified power.
        /// </summary>
        /// <param name="x">The base value of the expression.</param>
        /// <param name="y">The exponent value of the expression.</param>
        /// <returns></returns>
        public static Number Pow(Number x, Number y)
        {
            return new Number(System.Math.Pow(x.ToDouble(), y.ToDouble()));
        }

        /// <summary>
        /// Returns a pseudorandom number between 0 and 1.
        /// </summary>
        /// <returns></returns>
        public static Number Random()
        {
            return new Number(new System.Random().NextDouble());
        }

        /// <summary>
        /// Returns a supplied numeric expression rounded to the nearest integer.
        /// </summary>
        /// <param name="x">The value to be rounded to the nearest integer.</param>
        /// <returns></returns>
        public static Number Round(Number x)
        {
            return new Number(System.Math.Round(x.ToDouble()));
        }

        /// <summary>
        /// Returns the sign of the x, indicating whether x is positive, negative or zero.
        /// </summary>
        /// <param name="x">The numeric expression to test</param>
        /// <returns></returns>
        public static Number Sign(Number x)
        {
            if (x < 0)
                return new Number(-1);
            else if (x > 0)
                return new Number(1);
            else
                return x;
        }

        /// <summary>
        /// Returns the sine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Sin(Number x)
        {
            return new Number(System.Math.Sin(x.ToDouble()));
        }

        /// <summary>
        /// Returns the hyperbolic sine of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Sinh(Number x)
        {
            return new Number(System.Math.Sinh(x.ToDouble()));
        }

        /// <summary>
        /// Returns the square root of a number.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Sqrt(Number x)
        {
            return new Number(System.Math.Sqrt(x.ToDouble()));
        }

        /// <summary>
        /// Returns the tangent of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Tan(Number x)
        {
            return new Number(System.Math.Tan(x.ToDouble()));
        }

        /// <summary>
        /// Returns the hyperbolic tangent of a number.
        /// </summary>
        /// <param name="x">A numeric expression that contains an angle measured in radians.</param>
        /// <returns></returns>
        public static Number Tanh(Number x)
        {
            return new Number(System.Math.Tanh(x.ToDouble()));
        }

        /// <summary>
        /// Returns the integral part of the a numeric expression, x, removing any fractional digits. If x is already an integer, the result is x.
        /// </summary>
        /// <param name="x">A numeric expression.</param>
        /// <returns></returns>
        public static Number Trunc(Number x)
        {
            return new Number(System.Math.Truncate(x.ToDouble()));
        }
    }
}