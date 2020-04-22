namespace JavaScript.Errors
{
    public class Error : System.Exception
    {
        public virtual string Name { get; protected set; } = "Error";
        public new string Message { get; protected set; } = "";

        public Error() : base()
        {
            Message = $"Uncaught {Name}";
        }

        public Error(string message) : base(message)
        {
            Message = $"Uncaught {Name}: {message}";
        }
    }
}