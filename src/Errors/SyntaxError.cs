namespace JavaScript.Errors
{
    public class SyntaxError : Error
    {
        public override string Name { get; protected set; } = "SyntaxError";

        public SyntaxError() : base()
        { }

        public SyntaxError(string message) : base(message)
        { }
    }
}