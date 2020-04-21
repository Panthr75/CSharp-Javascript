namespace JavaScript
{
    public partial class Number
    {
        public override int GetHashCode()
        {
            string raw_value_string = raw_value.ToString();

            int lengthOfDecimals = raw_value_string.Length - new System.Text.RegularExpressions.Regex("\\..*$").Replace(raw_value_string, "").Length;

            return int.Parse((raw_value * System.Math.Pow(10, lengthOfDecimals)).ToString());
        }
    }
}