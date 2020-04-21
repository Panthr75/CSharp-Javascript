namespace JavaScript
{
    public partial class Number
    {
        public static bool operator <(Number a, Number b) => IsNaN(a) || IsNaN(b) ?
            false : // any comparison with NaN is always false
            a.raw_value < b.raw_value; // actually do the comparison

        public static bool operator <(Number a, float b) => a < new Number(b);
        public static bool operator <(Number a, double b) => a < new Number(b);
        public static bool operator <(Number a, decimal b) => a < new Number(b);
        public static bool operator <(Number a, sbyte b) => a < new Number(b);
        public static bool operator <(Number a, byte b) => a < new Number(b);
        public static bool operator <(Number a, short b) => a < new Number(b);
        public static bool operator <(Number a, ushort b) => a < new Number(b);
        public static bool operator <(Number a, int b) => a < new Number(b);
        public static bool operator <(Number a, uint b) => a < new Number(b);
        public static bool operator <(Number a, long b) => a < new Number(b);
        public static bool operator <(Number a, ulong b) => a < new Number(b);
        public static bool operator <(float a, Number b) => new Number(a) < b;
        public static bool operator <(double a, Number b) => new Number(a) < b;
        public static bool operator <(decimal a, Number b) => new Number(a) < b;
        public static bool operator <(sbyte a, Number b) => new Number(a) < b;
        public static bool operator <(byte a, Number b) => new Number(a) < b;
        public static bool operator <(short a, Number b) => new Number(a) < b;
        public static bool operator <(ushort a, Number b) => new Number(a) < b;
        public static bool operator <(int a, Number b) => new Number(a) < b;
        public static bool operator <(uint a, Number b) => new Number(a) < b;
        public static bool operator <(long a, Number b) => new Number(a) < b;
        public static bool operator <(ulong a, Number b) => new Number(a) < b;
    }
}