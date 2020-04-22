namespace JavaScript.Errors
{
    public class RangeError : Error
    {
        public override string Name { get; protected set; } = "RangeError";

        public RangeError() : base()
        { }

        public RangeError(string message) : base(message)
        { }
    }
}