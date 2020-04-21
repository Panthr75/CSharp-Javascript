namespace JavaScript
{
    public partial class Number
    {
        public static Number operator *(Number a, Number b) => IsNaN(a) || IsNaN(b) ?
            NaN : // any operation with or using NaN returns NaN
            new Number(a.raw_value * b.raw_value); // actually do the operation

        public static Number operator *(Number a, float b) => a * new Number(b);
        public static Number operator *(Number a, double b) => a * new Number(b);
        public static Number operator *(Number a, decimal b) => a * new Number(b);
        public static Number operator *(Number a, sbyte b) => a * new Number(b);
        public static Number operator *(Number a, byte b) => a * new Number(b);
        public static Number operator *(Number a, short b) => a * new Number(b);
        public static Number operator *(Number a, ushort b) => a * new Number(b);
        public static Number operator *(Number a, int b) => a * new Number(b);
        public static Number operator *(Number a, uint b) => a * new Number(b);
        public static Number operator *(Number a, long b) => a * new Number(b);
        public static Number operator *(Number a, ulong b) => a * new Number(b);
        public static Number operator *(float a, Number b) => new Number(a) * b;
        public static Number operator *(double a, Number b) => new Number(a) * b;
        public static Number operator *(decimal a, Number b) => new Number(a) * b;
        public static Number operator *(sbyte a, Number b) => new Number(a) * b;
        public static Number operator *(byte a, Number b) => new Number(a) * b;
        public static Number operator *(short a, Number b) => new Number(a) * b;
        public static Number operator *(ushort a, Number b) => new Number(a) * b;
        public static Number operator *(int a, Number b) => new Number(a) * b;
        public static Number operator *(uint a, Number b) => new Number(a) * b;
        public static Number operator *(long a, Number b) => new Number(a) * b;
        public static Number operator *(ulong a, Number b) => new Number(a) * b;
    }
}