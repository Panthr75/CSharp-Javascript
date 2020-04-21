namespace JavaScript
{
    /// <summary>
    /// An object that represents a number of any kind. All JavaScript numbers are 64-bit floating-point numbers.
    /// </summary>
    public partial class Number
    {
        protected double raw_value = 0;
        protected bool isNaN = false;

        private void Assign(float value)
        {
            if (float.IsNaN(value))
            {
                isNaN = true;
                return;
            }
            else
                isNaN = false;

            if (float.IsPositiveInfinity(value))
                raw_value = double.PositiveInfinity;
            else if (float.IsNegativeInfinity(value))
                raw_value = double.NegativeInfinity;
            else
                raw_value = value;
        }

        private void Assign(double value)
        {
            if (double.IsNaN(value))
            {
                isNaN = true;
                return;
            }
            else
                isNaN = false;

            if (double.IsPositiveInfinity(value))
                raw_value = double.PositiveInfinity;
            else if (double.IsNegativeInfinity(value))
                raw_value = double.NegativeInfinity;
            else
                raw_value = value;
        }

        private void Assign(decimal value)
        {
            isNaN = false;
            raw_value = decimal.ToDouble(value);
        }

        private void Assign(sbyte value) => raw_value = value;
        private void Assign(byte value) => raw_value = value;
        private void Assign(short value) => raw_value = value;
        private void Assign(ushort value) => raw_value = value;
        private void Assign(int value) => raw_value = value;
        private void Assign(uint value) => raw_value = value;
        private void Assign(long value) => raw_value = value;
        private void Assign(ulong value) => raw_value = value;
        private void Assign(Number value)
        {
            raw_value = value.raw_value;
            isNaN = value.isNaN;
        }

        public Number() { }

        public Number(object value)
        {
            double? result = value as double?;
            if (result.HasValue)
                raw_value = result.Value;
            else
                isNaN = true;
        }

        public Number(string value)
        {
            if (double.TryParse(value, out double result))
                raw_value = result;
            else
                isNaN = true;
        }

        public Number(float value) => Assign(value);
        public Number(double value) => Assign(value);
        public Number(decimal value) => Assign(value);
        public Number(sbyte value) => Assign(value);
        public Number(byte value) => Assign(value);
        public Number(short value) => Assign(value);
        public Number(ushort value) => Assign(value);
        public Number(int value) => Assign(value);
        public Number(uint value) => Assign(value);
        public Number(long value) => Assign(value);
        public Number(ulong value) => Assign(value);
        public Number(Number value) => Assign(value);
    }
}