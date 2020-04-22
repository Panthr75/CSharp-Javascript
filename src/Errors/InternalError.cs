namespace JavaScript.Errors
{
    public class InternalError : Error
    {
        public override string Name { get; protected set; } = "InternalError";

        public InternalError() : base()
        { }

        public InternalError(string message) : base(message)
        { }
    }
}