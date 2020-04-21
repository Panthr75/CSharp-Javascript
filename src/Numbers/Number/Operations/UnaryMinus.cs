namespace JavaScript
{
    public partial class Number
    {
        public static Number operator -(Number a)
        {
            if (!IsNaN(a))
                a.raw_value = -a.raw_value;

            return a;
        }
    }
}