namespace JavaScript
{
    public partial class Number
    {
        /// <summary>
        /// Converts this number to a C# Float
        /// </summary>
        /// <returns></returns>
        public float ToFloat() => (float)raw_value;
    }
}