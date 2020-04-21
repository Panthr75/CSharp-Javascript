namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Decimal
        /// </summary>
        /// <returns></returns>
        public decimal ToDecimal() => (decimal)raw_value;
    }
}