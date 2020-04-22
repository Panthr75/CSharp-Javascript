namespace JavaScript.Errors
{
    public class TypeError : Error
    {
        public override string Name { get; protected set; } = "TypeError";

        public TypeError() : base()
        { }

        public TypeError(string message) : base(message)
        { }
    }
}