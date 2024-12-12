namespace mpit.Core.Exceptions
{
    public class ApiException : ApplicationException
    {
        public ApiException() { }

        public ApiException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; private set; }
    }
}
