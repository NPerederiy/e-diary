namespace eDiary.API.Services.Security.Exceptions
{
    public class SecurityException : System.Exception
    {
        public string ParamName { get; protected set; }

        public SecurityException(string message) : base(message)
        {
        }

        public SecurityException(string message, string paramName) : base(message)
        {
            ParamName = paramName;
        }
    }
}
